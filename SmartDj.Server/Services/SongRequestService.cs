using SmartDJ.Server;
using SmartDj.Server.Data;
using SmartDj.Server.DTO;

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
                .Count(sr => sr.Played == false );
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
}