using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote
{
    /// <summary>
    /// 類型參數的條件約束
    /// 
    /// 當您定義泛型類別時，可限制用戶端程式碼在執行個體化類別時，型別引數可以使用哪些型別。 
    /// 如果用戶端程式碼嘗試使用條件約束所不允許的型別來執行個體化類別，就會產生編譯時期錯誤。 
    /// 這些限制稱為條件約束。
    /// https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
    /// </summary>
    public class WhereT_microsoft
    {
        public class Employee
        {
            private string name;
            private int id;

            public Employee(string s, int i)
            {
                name = s;
                id = i;
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int ID
            {
                get { return id; }
                set { id = value; }
            }
        }

        public class GenericList<T> where T : Employee
        {
            private class Node
            {
                private Node next;
                private T data;

                public Node(T t)
                {
                    next = null;
                    data = t;
                }

                public Node Next
                {
                    get { return next; }
                    set { next = value; }
                }

                public T Data
                {
                    get { return data; }
                    set { data = value; }
                }
            }

            private Node head;

            public GenericList() //constructor
            {
                head = null;
            }

            public void AddHead(T t)
            {
                Node n = new Node(t);
                n.Next = head;
                head = n;
            }

            public IEnumerator<T> GetEnumerator()
            {
                Node current = head;

                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }

            public T FindFirstOccurrence(string s)
            {
                Node current = head;
                T t = null;

                while (current != null)
                {
                    //The constraint enables access to the Name property.
                    if (current.Data.Name == s)
                    {
                        t = current.Data;
                        break;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
                return t;
            }
        }

        #region 同一型別參數可套用多個條件約束，而且條件約束本身可以是泛型型別

        //class EmployeeList<T> where T : Employee, IEmployee, System.IComparable<T>, new()
        //{
        //    // ...
        //}

        #endregion

        #region 限制多個參數

        class Base { }
        class Test<T, U>
            where U : struct
            where T : Base, new()
        { }

        #endregion
    }
}
