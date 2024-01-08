// Подключение пространств имен, содержащих базовые классы, коллекции, интерфейсы и другие утилиты, необходимые для работы класса.
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

// Объявление пространства имен для организации всех связанных классов в приложении ToDoList.
namespace ToDoList
{
    // Объявление класса TaskViewModel, который реализует интерфейс INotifyPropertyChanged для обновления UI при изменении данных.
    public class TaskViewModel : INotifyPropertyChanged
    {
        // Приватные поля класса для хранения состояния задачи.
        string name = "";
        private bool check = false;

        // Событие, которое вызывается при изменении свойства, для уведомления UI об этих изменениях.
        public event PropertyChangedEventHandler? PropertyChanged;
        // Команды для добавления и удаления задач, привязанные к элементам управления UI.
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; private set; }
        // Коллекция задач, которая уведомляет UI об изменениях при добавлении или удалении задач.
        public ObservableCollection<ToDoTask> Tasks { get; } = new ObservableCollection<ToDoTask>();

        // Конструктор, инициализирующий команды AddCommand и DeleteCommand.
        public TaskViewModel()
        {
            // Инициализация команды AddCommand, которая добавляет новую задачу в список.
            AddCommand = new Command(() =>
            {
                Tasks.Add(new ToDoTask(Name, Check));
                Name = "";
                Check = false;
                Debug.WriteLine($"Task've been added: {Name} ");
            });

            // Инициализация команды DeleteCommand, которая удаляет задачу из списка.
            DeleteCommand = new Command<ToDoTask>(DeleteTask);
        }

        // Метод DeleteTask, вызываемый командой DeleteCommand для удаления задачи.
        private void DeleteTask(ToDoTask task)
        {
            if (task != null)
            {
                if (task.Check)
                {
                    Tasks.Remove(task);
                    OnPropertyChanged(nameof(Tasks));
                    Debug.WriteLine($"Deleted task: {task.Name}");
                }
                else
                {
                    Debug.WriteLine($"Task {task.Name} cannot be deleted because it is not checked.");
                }
            }
            else
            {
                Debug.WriteLine($"There is no task");
            }
        }

        // Свойство Name, вызывающее OnPropertyChanged при изменении, для уведомления UI.
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        // Свойство Check, вызывающее OnPropertyChanged при изменении, для уведомления UI.
        public bool Check
        {
            get => check;
            set
            {
                check = value;
                OnPropertyChanged();
            }
        }

        // Метод OnPropertyChanged, который вызывает событие PropertyChanged для указанного свойства.
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
