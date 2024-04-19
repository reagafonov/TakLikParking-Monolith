using Domain.Entities;

namespace Infrastructure.Telegram;

public class TelegramRegistrationBuilder
{
    private TelegramUser _telegramUser = new TelegramUser();
    private TelegramContact _telegramContact = new TelegramContact();
    private TelegramCar _telegramCar = new TelegramCar();
    private TelegramCarNumber _telegramCarNumber = new TelegramCarNumber();
    private MessageType _messageType = MessageType.None;
    private Dictionary<MessageType, IMessageOptions> _dictionary = new Dictionary<MessageType, IMessageOptions>();
    
    public void AddChatId(string chatId)
    {
        _telegramContact.ChatID = chatId;
    }

    public void AddName(string userName)
    {
        _telegramContact.Name = userName;
    }

    public void AddPhone(string phone)
    {
        _telegramContact.PhoneNumber = phone;
    }

    public void AddCarNumber(string? carNumber)
    {
        _telegramCarNumber.Number = carNumber;
    }

    public void SetMessageOptions(MessageType message,NotifyOptions options)
    {
        _dictionary[message] = new TelegramMessageOptions()
        {
            NotifyOptions = options
        };
    }

    public IUserData<Guid> Build()
    {
        _telegramCar.Id = new Guid();
        _telegramCar.Number = _telegramCarNumber;
        _telegramCar.MessageOptions = _dictionary;
        _telegramCar.RegistrationData = new List<IUserData<Guid>>()
        {
            _telegramUser
        };
        _telegramUser.Cars = new List<ICar<Guid>>()
        {
            _telegramCar
        };
        _telegramUser.Contacts = new List<IContact>()
        {
            _telegramContact
        };
        return _telegramUser;
    }
}