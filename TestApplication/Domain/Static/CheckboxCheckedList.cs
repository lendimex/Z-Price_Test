using System.Collections.Generic;

namespace Domain.Static
{
    public static class CheckboxCheckedList
    {

        private static List<string> checkedList;
        public static List<string> CheckedList
        {
            get
            {
                if (checkedList == null)
                    return new List<string>();
                return checkedList;
            }
            set
            {
                checkedList = value;
            }
        }
    }
}
