using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfaceMenuTest
    {
        private readonly MainMenu r_MainMenu;

        private void buildMenu()
        {
            MenuItem dateTimeSubMenu = createDateTimeSubMenu();
            MenuItem versionSubMenu = createVersionSubMenu();

            r_MainMenu.RootMenuItem.AddSubItem(dateTimeSubMenu);
            r_MainMenu.RootMenuItem.AddSubItem(versionSubMenu);
        }

        private MenuItem createDateTimeSubMenu()
        {
            MenuItem dateTimeSubMenu = new MenuItem("Show Current Date/Time");
            MenuItem dateItem = new MenuItem("Show Current Date");
            MenuItem timeItem = new MenuItem("Show Current Time");

            dateItem.AddListener(new DateShowListener());
            timeItem.AddListener(new TimeShowListener());
            dateTimeSubMenu.AddSubItem(dateItem);
            dateTimeSubMenu.AddSubItem(timeItem);

            return dateTimeSubMenu;
        }

        private MenuItem createVersionSubMenu()
        {
            MenuItem versionSubMenu = new MenuItem("Version and Capitals");
            MenuItem capitalsItem = new MenuItem("Count Capitals");
            MenuItem versionItem = new MenuItem("Show Version");

            capitalsItem.AddListener(new CapitalsCountListener());
            versionItem.AddListener(new VersionShowListener());
            versionSubMenu.AddSubItem(capitalsItem);
            versionSubMenu.AddSubItem(versionItem);

            return versionSubMenu;
        }

        public InterfaceMenuTest()
        {
            r_MainMenu = new MainMenu("Interfaces Main Menu");
            buildMenu();
        }

        public void Show()
        {
            r_MainMenu.Show();
        }
    }
}