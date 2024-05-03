using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SmartDj.Server.Data;
using SmartDj.Shared.DTO;
using SmartDj.Shared.Models;

namespace SmartDj.Server.Services
{
    public class FormTemplateService
    {
        private readonly DataContext _dataContext;

        public FormTemplateService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ServiceResponse<FormTemplate> GetActiveTemplate()
        {
            var formTemplate = _dataContext.FormTemplates.Where(t => t.IsActive == true).FirstOrDefault();
            if (formTemplate != null)
            {
                return new ServiceResponse<FormTemplate>(formTemplate);
            }

            return new ServiceResponse<FormTemplate>("No active template found.");
        }

        public ServiceResponse<string> AddForm(string formTemplate)
        {
            var newFormTemplate = new FormTemplate { HtmlContent = formTemplate };
            _dataContext.FormTemplates.Add(newFormTemplate);
            _dataContext.SaveChanges();
            return new ServiceResponse<string>(data: "New form added successfully.");
        }

        public ServiceResponse<List<FormTemplate>> GetAllTemplates()
        {
            var templates = _dataContext.FormTemplates.ToList();
            return new ServiceResponse<List<FormTemplate>>(templates);
        }

        public ServiceResponse<FormTemplate> GetTemplateByID(int id)
        {
            var template = _dataContext.FormTemplates.Find(id);
            if (template != null)
            {
                return new ServiceResponse<FormTemplate>(template);
            }

            return new ServiceResponse<FormTemplate>("Template not found.");
        }

        public ServiceResponse<bool> AddUpdateTemplate(PostTemplateDto postTemplateDto)
        {
            if (postTemplateDto.Id == 0)
            {
                var newTemplate = new FormTemplate { 
                    HtmlContent = postTemplateDto.TemplateContent, 
                    Name = postTemplateDto.Name};
                _dataContext.FormTemplates.Add(newTemplate);
                _dataContext.SaveChanges();
                return new ServiceResponse<bool>(true);
            }
            else
            {
                var template = _dataContext.FormTemplates.Where(t => t.Id == postTemplateDto.Id).FirstOrDefault();
                template.Name = postTemplateDto.Name;
                template.HtmlContent = postTemplateDto.TemplateContent;
                _dataContext.SaveChanges();
                return new ServiceResponse<bool>(true);
            }
        }

        public ServiceResponse<bool> RemoveTemplate(int id)
        {
            var template = _dataContext.FormTemplates.Find(id);
            if (template != null)
            {
                _dataContext.FormTemplates.Remove(template);
                _dataContext.SaveChanges();
                return new ServiceResponse<bool>(true);
            }

            return new ServiceResponse<bool>(false);
        }

        public ServiceResponse<bool> SetAsActive(int id)
        {
            // Start by setting all entries to inactive
            var templates = _dataContext.FormTemplates.ToList();
            foreach (var template in templates)
            {
                template.IsActive = false;
            }

            // Then set the specified entry to active
            var selectedTemplate = templates.FirstOrDefault(t => t.Id == id);
            if (selectedTemplate != null)
            {
                selectedTemplate.IsActive = true;
                _dataContext.SaveChanges(); // Save changes to the database
                return new ServiceResponse<bool> { Data = true, Message = "Template set as active successfully.", Success = true };
            }
    
            // If we did not find the template with the given ID, handle the error
            return new ServiceResponse<bool> { Data = false, Message = "Template not found.", Success = false };
        }

    }
}
