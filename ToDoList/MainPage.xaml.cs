using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Xml.Linq;


namespace ToDoList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent(); //загрузки и применения разметки XAML, определенной в MainPage.xaml \
                                   //отвечает за создание  всего интерфейса, описанных в XAML
            BindingContext = new TaskViewModel();// указания того объекта, чьи свойства будут связаны \
                                                 // с элементами пользовательского интерфейса на странице. В этом случае создается экземпляр TaskViewModel
        }

    }


}
