using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task123
{
    class DynamicArray<T> : IEnumerable
    {

        public T[] array;
        public int capacity;
        public int length;
        //Конструктор 1
        public DynamicArray()
        {
            int defaultCapacity = 8;
            array = new T[defaultCapacity];
            capacity = defaultCapacity;
            length = 0;
        }

        //Конструктор 2
        public DynamicArray(int initialCapacity)
        {
            array = new T[initialCapacity];
            capacity = initialCapacity;
            length = 0;
        }

        //Конструктор 3
        public DynamicArray(T[] array)

        {
            length = array.Length;
            this.array = new T[length];
            for (int i = 0; i < length; i++) { this.array[i] = array[i]; }
            capacity = length;
        }

        //Индексатор
        public T this[int index]
        {
            set
            {
                array[index] = value;
            }
            get
            {
                return array[index];
            }
        }


        public IEnumerator GetEnumerator()
        {
            return array.GetEnumerator();
        }



        // Реальная ёмкость массива
        public int Capacity
        {
            get { return capacity; }
            set { }

        }

        // Длина заполненной части массива
        public int Length
        {
            get { return length; }
            set { }
        }



        //Добавление элемента в конец массива///////////////////////////////////////////////////////////////////////////////////////////
        public void Add(T newmember)
        {

            Insert(length, newmember);
            //if (length == capacity)
            //{
            //    capacity *= 2;
            //    Array.Resize(ref array, capacity);
            //}
            //array[length] = newmember;
            //length++;

        }

        //Добавление массива в конец ///////////////////////////////////////////////////////////////////////////////////////////////////
        public T[] AddRange(T[] newArray)
        {
            int CapasityNew = newArray.Length;
            if (CapasityNew > (capacity - length))
            {
                capacity = CapasityNew + length;
                Array.Resize(ref array, (capacity *= 2));
            }
            for (int i = 0; i < CapasityNew; i++)
            {
                array[length] = newArray[i];
                length++;
            }
            return array;
        }


        //Удаление элемента массива ///////////////////////////////////////////////////////////////////////////////////////////////////
        public bool Remove(T deleteMember)
        {
            T[] a = new T[1];
            int index = Array.FindIndex(array, item => (item.Equals(deleteMember)));
            if (index < 0)
            {
                return false;
            }
            else
            {
                if (index != (capacity - 1))
                {
                    for (int i = index; i < (capacity - 1); i++)
                    {
                        array[i] = array[i + 1];
                    }

                }
                array[capacity - 1] = a[0];
                length--;
                return true;
            }



        }

        //Добавление элемента произвольно//////////////////////////////////////////////////////////////////////////////////////////////
        public T[] Insert(int index, T newmember)
        {


            if ((index < capacity) && (index >= 0))
            {

                if (capacity == length)
                {
                    capacity = 2 * capacity;
                    Array.Resize(ref array, capacity);
                }
                if (index > length) { throw new ArgumentOutOfRangeException(); }
                else
                {
                    for (int i = length; i > index; i--)
                    {
                        array[i] = array[i - 1];
                    }
                    array[index] = newmember;
                    length++;
                    return array;
                }
            }
            else
            { throw new ArgumentOutOfRangeException("Указанный индекс больше ёмкости массива"); }
        }



    }
}
