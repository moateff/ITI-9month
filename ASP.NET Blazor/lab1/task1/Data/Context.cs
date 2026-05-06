namespace task1.Data;

public static class Context
{   
    private static int _nextTraineeId = 0;
    public static int NextTraineeId {
        get 
        {
            return ++_nextTraineeId;
        } 
    }

    private static int _nextTrackId = 0;
    public static int NextTrackId { 
        get
        {
            return ++_nextTrackId;
        } 
    }

    public static IEnumerable<Trainee> Trainees { get; private set; } = new List<Trainee>()
    {
        new Trainee()
        {
            Id = NextTraineeId,
            Name = "Trainee 1",
            Gender = Gender.Male,
            Email = "trainee1@ex.com",
            MobileNumber = "1234567890",
            BirthDate = new DateOnly(2000, 1, 1),
            IsGraduated = false,
            TrackId = 1
        },
        new Trainee()
        {
            Id = NextTraineeId,
            Name = "Trainee 2",
            Gender = Gender.Female,
            Email = "trainee2@ex.com",
            MobileNumber = "1234567890",
            BirthDate = new DateOnly(2000, 1, 1),
            IsGraduated = false,
            TrackId = 2
        },
        new Trainee()
        {
            Id = NextTraineeId,
            Name = "Trainee 3",
            Gender = Gender.Male,
            Email = "trainee3@ex.com",
            MobileNumber = "1234567890",
            BirthDate = new DateOnly(2000, 1, 1),
            IsGraduated = false,
            TrackId = 3
        }
    };

    public static IEnumerable<Track> Tracks { get; private set; } = new List<Track>()
    {
        new Track()
        {
            Id = NextTrackId,
            Name = "Track 1",
            Description = "Track 1 description"
        },
        new Track()
        {
            Id = NextTrackId,
            Name = "Track 2",
            Description = "Track 2 description"
        },
        new Track()
        {
            Id = NextTrackId,
            Name = "Track 3",
            Description = "Track 3 description"
        }
    };
}