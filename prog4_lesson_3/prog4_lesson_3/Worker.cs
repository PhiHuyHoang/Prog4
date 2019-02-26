namespace prog4_lesson_3
{
    public class Worker
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsOnHoliday { get; set; }
        public bool IsSick { get; set; }

        public override string ToString()
        {
            string output = $"{Name}, Phone: {PhoneNumber}";
            if (IsSick) output += " (is currently ill) ";
            if (IsOnHoliday) output += " (is currently on holiday) ";
            return output;
        }
    }
}