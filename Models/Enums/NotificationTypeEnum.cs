namespace itinera_io_backend.Models.Enums
{
    public enum NotificationTypeEnum
    {
        TripAdded, // user was added to a trip
        TripUpdated, // trip details were updated by owner
        ActivityAdded, //an activity was suggested by a participant
        ActivityVoted, //informing activity owner that a participant has voted on an activity, feature not supported yet
        ActivityUpdated, //activity details were updated by owner
        ItineraryGenerated // itinerary was generated and voting is closed
    }
}