namespace itinera_io_backend.Models.Enums
{
    public enum NotificationTypeEnum
    {
        TripAdded, // user was added to a trip -0
        TripUpdated, // trip details were updated by owner -1
        ActivityAdded, //an activity was suggested by a participant -2
        ActivityVoted, //informing activity owner that a participant has voted on an activity, feature not supported yet -3
        ActivityUpdated, //activity details were updated by owner -4
        ItineraryGenerated // itinerary was generated and voting is closed -5
    }
}