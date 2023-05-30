using System.ComponentModel.DataAnnotations;

namespace Core.Domain.ComplexTypes
{
    public class Enums
    {
        public enum RecordStatu
        {
            None = 0,
            Active = 1,
            Passive = 2,
        }

        public enum FileType
        {
            None,
            Xls,
            Xlsx,
            Doc,
            Pps,
            Pdf,
            Img,
            Mp4
        }

        public enum InvoiceTypes
        {
            Cash = 1,
            Card = 2,
            Other = 3,
        }


        public enum OrderStatus
        {
            None = 0,
        }

        public enum ConfirmationTypes
        {
            None = 0
        }

        public enum NotificationType
        {
            None = 0,

        }
        public enum NotificationActionType
        {
            None = 0

        }

        public enum ConfirmStatus
        {
            Waiting = 0,
            Confirmed = 1,
            Rejected = 2,
        }

        public enum CultureType
        {
            None = 0,
            [Display(Name = "en-US")]
            US = 1,
            [Display(Name = "nl-NL")]
            NL = 2,

        }

        public enum AuthenticatorType
        {
            None = 0,
            Email = 1,
            Otp = 2
        }

        public enum UserType
        {
            None = 0,
            MainUser = 1,
            SubUser = 2
        }

        public enum CustomerType
        {
            None = 0,
            Regular = 1,
            Irregular = 2
        }

        public enum AddressType
        {
            None = 0,
            Personal = 1,
            Corporate = 2
        }

        public enum OperationStatus
        {
            None = 0,
            InProgress = 1,
            Complete = 2,
            PaymentIsAwaited = 3,
            PaymentReceived = 4
        }

        public enum PaymentStatus
        {
            None = 0,
            Pending = 1,
            Complete = 2
        }

        public enum PaymentMethod
        {
            None = 0,
            Card = 1,
            Cash = 2
        }
        public enum NoteTypes
        {
            None = 0,
        }

        public enum RepeatRuleType
        {
            None = 0,
            AllDay = 1,
            EveryDay = 2,
            EveryWeek = 3,
            EveryMonth = 4,
            EveryYear = 5,
            Weekdays = 6,
            CustomRepeatDaily = 7,
            CustomInterval = 8,
            SpecificDayOfMonthRepeat = 9,
            RepeatWeeklySelectedDays = 10,
            EveryXDayOfTheWeek = 11,
            CustomEveryMonth = 12,
            CustomYearly = 13,
        }

        public enum TimeUnit
        {
            None = 0,
            Day = 1,
            Week = 2,
            Month = 3,
            Year = 4,
            XDayOfTheWeek = 5
        }

        public enum RepeatEndType
        {
            None = 0,
            Never = 1,
            ByDate = 2,
            ByCount = 3
        }
    }
}
