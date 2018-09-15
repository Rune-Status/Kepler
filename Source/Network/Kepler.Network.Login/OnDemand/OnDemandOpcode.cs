namespace Kepler.Network.Login.OnDemand
{
    public enum OnDemandOpcode
    {
        FileRequest = 0,

        PriorityFileRequest = 1,

        ClientLoggedIn = 2, //TODO Do more research on this 

        ClientLoggedOut = 3, //TODO Do more research on this

        EncryptionKeyUpdate = 4,

        ClientConnected = 5,

        ClientDisconnected = 6
    }
}