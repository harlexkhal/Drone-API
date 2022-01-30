using System.ComponentModel;

namespace DroneAPI.Models
{
    public enum DroneModelType
    {
        [Description("Light weight")]
        Lightweight = 1,
        [Description("Middle weight")]
        Middleweight,
        [Description("Cruiser weight")]
        Cruiserweight,
        [Description("Client user")]
        Client,
        [Description("Heavy weight")]
        Heavyweight
    }

    public enum DroneState
    {
        IDLE = 1,
        LOADING,
        LOADED,
        DELIVERING,
        DELIVERED,
        RETURNING
    }
}
