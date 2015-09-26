using System;
using GameSparks;

namespace GameSparks.Platforms
{

    public interface IControlledWebSocket : IGameSparksWebSocket
    {
        void TriggerOnClose();
        void TriggerOnOpen();
        void TriggerOnError(string message);
        void TriggerOnMessage(string message);
        int SocketId { get; }
    }

}