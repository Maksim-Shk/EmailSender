namespace EmailSender.Client.Models
{
    public class MailListVm
    {       /// <summary>
            /// Список писем
            /// </summary>
        public IList<GetAllMailsModel> Mails { get; set; }
    }
}
