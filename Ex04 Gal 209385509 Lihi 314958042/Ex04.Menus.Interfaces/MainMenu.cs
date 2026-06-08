namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private readonly MenuItem r_RootMenuItem;

        public MainMenu(string i_Title)
        {
            r_RootMenuItem = new MenuItem(i_Title);
        }

        public MenuItem RootMenuItem
        {
            get { return r_RootMenuItem; }
        }

        public void Show()
        {
            r_RootMenuItem.Show(true);
        }
    }
}