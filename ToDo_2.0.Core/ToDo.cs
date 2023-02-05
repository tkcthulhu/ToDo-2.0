using System;
namespace ToDo_2._0
{
    public class TodoList : IDisplayable, IResettable
    {
        public string[] Todos
        { get; private set; }

        private int nextOpenIndex;

        public TodoList()
        {
            Todos = new string[5];
            nextOpenIndex = 0;
        }

        public bool Add(string todo)
        {
            if (nextOpenIndex > 4)
            {
                Console.WriteLine("Your To Do list is full! Please delete an item to continue adding tasks");
                return false; 
            }
            Todos[nextOpenIndex] = todo;
            nextOpenIndex++;
            return true;
        }

        public string Display()
        {
            string[] items = new string[5];
            int itemNum = 1;
            foreach (string item in Todos)
            {
                Console.WriteLine($"{itemNum}. {item}");
                items[itemNum-1]=($"{itemNum}. {item}");
                itemNum++;
            }

            return string.Join(" ", items);
        }

        public void Remove(int index)
        {
            index = index - 1;
            string[] newTodos = new string[5];
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                if (i == index)
                {
                    i++;
                    continue;
                }
                newTodos[count] = Todos[i];
                count++;
            }
            Todos = newTodos;
            nextOpenIndex--;
        }

        public void Reset()
        {
            Todos = new string[5];
        }
    }
}

