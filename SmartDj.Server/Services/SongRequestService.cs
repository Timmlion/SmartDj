using SmartDj.Server.Data;
using SmartDj.Shared.DTO;
using SmartDj.Shared.Models;

namespace SmartDj.Server.Services;

public class SongRequestService
{
    private DataContext _dataContext;

    public SongRequestService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public ServiceResponse<int> AddSongToList(PostSongRequestDTO postSongRequestDto)
    {
        try
        {
            SongRequest newSongRequest = new SongRequest
            {
                SongTitle = postSongRequestDto.SongTitle,
                RequestorName = postSongRequestDto.RequestorName,
                DedicateeName = postSongRequestDto.DedicateeName,
                Message = postSongRequestDto.Message
            };
            
            _dataContext.SongRequests.Add(newSongRequest);
            _dataContext.SaveChanges();
            
            var songsCount = _dataContext.SongRequests
                .Count(sr => sr.WasPlayed == false );
            return new ServiceResponse<int>(songsCount);
        }
        catch(Exception ex)
        {
            return new ServiceResponse<int>("Błąd podczas dodawania piosenki");
        }
    }

    public ServiceResponse<List<SongRequest>> GetRequestedSongsList()
    {
        List<SongRequest> result;

        result = _dataContext.SongRequests.ToList();

        if (result != null)
        {
            return new ServiceResponse<List<SongRequest>>(result);
        }
        return new ServiceResponse<List<SongRequest>>("Problem z pobraniem listy utworów");
    }

    public ServiceResponse<string> ClearSongList()
    {
        try
        {
            var records = _dataContext.SongRequests;
            
            _dataContext.SongRequests.RemoveRange(records);
            _dataContext.SaveChanges();
            return new ServiceResponse<string>(data: "Baza danych wyczyszczona poprawnie");
        }
        catch(Exception ex)
        {
            return new ServiceResponse<string>("Błąd podczas czyszczenia bazy danych");
        }
    }

    public ServiceResponse<bool> UpdateSongRequest(PostSongRequestUpdateDto songRequestUpdate)
    {
        try
        {
            var song = _dataContext.SongRequests.Where(s => s.Id == songRequestUpdate.Id).FirstOrDefault();
            song.WasPlayed = songRequestUpdate.WasPlayed;
            _dataContext.SaveChanges();
            return new ServiceResponse<bool>(true);
        }
        catch (Exception ex)
        {
            return new ServiceResponse<bool>("Błąd podczas aktualizacji piosenki");
        }

    }
}