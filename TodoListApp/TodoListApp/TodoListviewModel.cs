using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace TodoListApp
{
	public class TodoListviewModel
	{
        public ObservableCollection<TodoItem> TodoItems { get; set; }

        public TodoListviewModel()
		{
			TodoItems = new ObservableCollection<TodoItem>();

			TodoItems.Add(new TodoItem("Task 1", false));
			TodoItems.Add(new TodoItem("Task 2", false));
			TodoItems.Add(new TodoItem("Task 3", true));
		}

        public string Input { get; set; }

		public ICommand AddTodoCommand => new Command(AddTodoItem);

		void AddTodoItem()
		{
			TodoItems.Add(new TodoItem(Input, false));
		}

		public ICommand RemoveTodoCommand => new Command(RemoveTodoItem);

		void RemoveTodoItem(object o)
		{
			var item = o as TodoItem;
			TodoItems.Remove(item);
		}
	}
}