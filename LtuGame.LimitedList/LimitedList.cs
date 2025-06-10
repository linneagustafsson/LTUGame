using System.Collections;

namespace LtuGame.LimitedList
{
    public class LimitedList<T> :IEnumerable<T>
    {
        private readonly int _capacity; //kapaciteten för listan, hur många objekt den kan hantera
        protected List<T> _list;
        //List<T> är en generisk lista som kan hantera olika typer av objekt

        public int Count => _list.Count;
        public bool IsFull => _capacity <= Count;
        public T this[int index] => _list[index];
       
        //{
        //    get => _list[index]; 
        //    set => _list[index] = value;
        //}

        public LimitedList(int capacity)
        {
            _capacity = Math.Max(capacity, 2);
            _list = new List<T>(_capacity);
        }

        public virtual bool Add(T item) //virtual gör att vi kan override metoden i en subklass
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));
            
            if (IsFull) return false;
            _list.Add(item); return true;
        }

        public void Print(Action<T> action)
        { 
            //_list.ForEach(x=>action(x));
            //_list.ForEach(action); //använder en action för att skriva ut varje item i listan
            _list.ForEach(x => action?.Invoke(x));//?. gör att vi kan anropa action om den inte är null

        }
        public IEnumerator<T> GetEnumerator()
        {
            //return _list.GetEnumerator();
            foreach (var item in _list)
            {
              yield return item;
            }//yield return gör att vi kan iterera över listan utan att skapa en ny lista
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        //ingen accessmodifier för att IEnumerable.GetEnumerator() är en del av IEnumerable interfacet
        //IEnumberable är ett interface som gör att vi kan använda foreach på LimitedList<T>
        //LimitedList<T> är en generisk klass som kan hantera olika typer av objekt

    }

}
