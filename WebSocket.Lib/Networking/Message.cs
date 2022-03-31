namespace WebSocketManager.Common
{
    public enum MessageType
    {
        Login = 0,
        Text = 1,
        ConnectionEvent = 2,
        MethodInvocation = 3,
        MethodReturnValue = 4
    }

    public class Message
    {
        public MessageType MessageType { get; set; }
        public dynamic Data { get; set; }
    }
}