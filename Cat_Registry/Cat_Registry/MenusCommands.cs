using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cat_Database.Menus;
using static Cat_Database.Editing;
using static Cat_Database.Sorting;
using static Cat_Database.Filtering;
using static Cat_Database.IOXML;
using static Cat_Database.Program;

namespace Cat_Database
{
     static class MenusCommands
    {
       
       
        public static CommandInfo[] mainMenuArray = {
            new CommandInfo("створити тестові дані", CreateTestingData),
            new CommandInfo("видалити дані        ", Clear),
            new CommandInfo("редагувати дані  >>  ", OperateEditMenu),
            new CommandInfo("сортувати дані   >>  ", OperateSortMenu),
            new CommandInfo("фільтрувати дані >>  ", OperateFilterMenu),
            new CommandInfo("Зберегти дані в файл ", xmlController.Save),
            new CommandInfo("Зчитати дані з файлу ", xmlController.Load),
            new CommandInfo("Дякуємо, що були з нами!!!", null),

        };

        public static CommandInfo[] editSubMenuArray = {
            new CommandInfo(" додати нового кота  ", AddNewCat),
            new CommandInfo(" видалити за номером ", DeleteByNumber),
            new CommandInfo("редагувати за номером", EditByNumber),
            new CommandInfo("повернутись в головне меню", null),

        };

        public static CommandInfo[] sortSubMenuArray = {
            new CommandInfo("сортувати за ім'ям   ", SortByName),
            new CommandInfo("сортувати за породою ", SortByBreed),
            new CommandInfo("сортувати за кольором", SortByColor),
            new CommandInfo("сортувати за віком   ", SortByAge),
            new CommandInfo("сортувати за вагою   ", SortByWeight),
            new CommandInfo("повернутись в головне меню", null),

        };

        public static CommandInfo[] filterSubMenuArray = {
            new CommandInfo("фільтрувати за ім'ям   ", OperateFilterByName),
            new CommandInfo("фільтрувати за породою ", OperateFilterByBreed),
            new CommandInfo("фільтрувати за кольором", OperateFilterByColor),
            new CommandInfo("фільтрувати за віком   ", OperateFilterByAge),
            new CommandInfo("фільтрувати за вагою   ", OperateFilterByWeight),
            new CommandInfo("відмінити всі фільтри  ", CancelAllFilters),
            new CommandInfo("зберегти відібране в файл", txtController.Save),
            new CommandInfo("повернутись в головне меню", null),
        };

        public static CommandInfo[] filterByNameSubMenuArray = {
            new CommandInfo("+імена, що починаються від літери...  ", OperateFilterByNameAfterLetter),
            new CommandInfo("+імена, що починаються до літери...", OperateFilterByNameBeforeLetter),
            new CommandInfo("+імена, що починаються з літери...", OperateFilterByNameAtLetter),
            new CommandInfo("повернутись в попереднє меню", null),
        };



        public static CommandInfo[] filterByBreedSubMenuArray = {
            new CommandInfo("+породи, що починаються від літери...  ", OperateFilterByBreedAfterLetter),
            new CommandInfo("+породи, що починаються до літери...", OperateFilterByBreedBeforeLetter),
            new CommandInfo("+порода, за точно введеною назвою ", OperateFilterByBreedExact),
            new CommandInfo("повернутись в попереднє меню", null),
        };



        public static CommandInfo[] filterByColorSubMenuArray = {
            new CommandInfo("+кольори, що починаються від літери...  ", OperateFilterByColorAfterLetter),
            new CommandInfo("+кольори, що починаються до літери...", OperateFilterByColorBeforeLetter),
            new CommandInfo("+колір, за точно введеною назвою ", OperateFilterByColorExact),
            new CommandInfo("повернутись в попереднє меню", null),
        };



        public static CommandInfo[] filterByAgeSubMenuArray = {
            new CommandInfo("+вік, не менший ніж ... ", OperateFilterByAgeMoreThan),
            new CommandInfo("+вік, не більший ніж ... ", OperateFilterByAgeLessThan),
            new CommandInfo("+вік, що дорівнює ...", OperateFilterByAgeEqualTo),
            new CommandInfo("повернутись в попереднє меню", null),
        };



        public static CommandInfo[] filterByWeightSubMenuArray = {
            new CommandInfo("+вага, не менша ніж ... ", OperateFilterByWeightMoreThan),
            new CommandInfo("+вага, не більша ніж ... ", OperateFilterBWeightLessThan),
            new CommandInfo("+вага, що дорівнює ...", OperateFilterByWeightEqualTo),
            new CommandInfo("повернутись в попереднє меню", null),
        };



    }
}
