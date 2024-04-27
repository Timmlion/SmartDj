using SmartDj.Shared.Models;

namespace SmartDj.Gui.Services;

public class SongRequestService
{
    public IEnumerable<SongRequest>? GetSongRequests()
    {
        return new List<SongRequest>
        {
            new SongRequest{Id = 1, DateCreated = DateTime.Now, RequestorName = "Zuzia", DedicateeName = "Zbigniew", SongTitle = "Tytuł piosenki", Message = "Dedykacja, Lorem ipsum pipsum sripsum tripsum bombiksum fafarafa fifirafifo", WasPlayed = true},
            new SongRequest{Id = 2, DateCreated = DateTime.Now, RequestorName = "Zuzia2", DedicateeName = "Zbigniew", SongTitle = "Tytuł piosenki", Message = "Dedykacja, Lorem ipsum pipsum sripsum tripsum bombiksum fafarafa fifirafifo", WasPlayed = false},
            new SongRequest{Id = 3, DateCreated = DateTime.Now, RequestorName = "Zuzia3", DedicateeName = "Zbigniew", SongTitle = "Tytuł piosenki", Message = "Dedykacja, Lorem ipsum pipsum sripsum tripsum bombiksum fafarafa fifirafifo", WasPlayed = false},
            new SongRequest{Id = 4, DateCreated = DateTime.Now, RequestorName = "Zuzia4", DedicateeName = "Zbigniew", SongTitle = "Tytuł piosenki", Message = "Dedykacja, Lorem ipsum pipsum sripsum tripsum bombiksum fafarafa fifirafifo", WasPlayed = false},
        };
    }
}