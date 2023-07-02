namespace EmailSender.Application.Mails.Queries.GetAllMail
{
    public class MailListVm
    {
        /// <summary>
        /// Список писем
        /// </summary>
        public IList<MailDto> Mails { get; set; }
    }
}
