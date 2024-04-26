using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SmartDj.Server.Data;
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
            var formTemplate = _dataContext.FormTemplates.FirstOrDefault();
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

        public ServiceResponse<string> AddTemplate(string templateContent)
        {
            var newTemplate = new FormTemplate { HtmlContent = templateContent };
            _dataContext.FormTemplates.Add(newTemplate);
            _dataContext.SaveChanges();
            return new ServiceResponse<string>(data: "Template added successfully.");
        }

        public ServiceResponse<string> RemoveTemplate(int id)
        {
            var template = _dataContext.FormTemplates.Find(id);
            if (template != null)
            {
                _dataContext.FormTemplates.Remove(template);
                _dataContext.SaveChanges();
                return new ServiceResponse<string>(data: "Template removed successfully.");
            }

            return new ServiceResponse<string>("Template not found.");
        }
    }
}
