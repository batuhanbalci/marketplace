using System;

namespace MarketplaceBlazorApp.Shared
{
    public class MessageModel
    {
        private int messageID;
        private string message;
        private UserModel fromUser;
        private UserModel toUser;
        private MessageStates state;
        private MessageModel replyToMessage;
        private ItemModel item;
        private DateTime sendTime;

        public int MessageID { get => messageID; set => messageID = value; }
        public string Message { get => message; set => message = value; }
        public UserModel FromUser { get => fromUser; set => fromUser = value; }
        public UserModel ToUser { get => toUser; set => toUser = value; }
        public MessageStates State { get => state; set => state = value; }
        public MessageModel ReplyToMessage { get => replyToMessage; set => replyToMessage = value; }
        public ItemModel Item { get => item; set => item = value; }
        public DateTime SendTime { get => sendTime; set => sendTime = value; }
    }
}
