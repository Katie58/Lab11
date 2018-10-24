using System;

namespace Lab11
{
    class Menu
    {
        private string nav;
        public string Nav { get; set; }
        private Action page;
        public Action Page { get; set; }

        public Menu(string nav, Action page)
        {
            Nav = nav;
            Page = page;
        }

        public void DisplayTitle()
        {
            Console.WriteLine("");
        }
    }
}
