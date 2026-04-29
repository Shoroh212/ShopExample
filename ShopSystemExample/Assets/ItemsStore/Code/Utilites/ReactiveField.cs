using UnityEngine.Events;

namespace ItemsStore.Code.Utilites
{
    public class ReactiveField<T> where T : class
    {
        public UnityEvent<T, T> OnValueChanged = new();
        private T _value;


        public T Value
        {
            get { return _value; }

            set
            {
                var oldValue = _value;
                _value = value;

                OnValueChanged?.Invoke(oldValue, value);
            }
        }

        public ReactiveField(T value)
        {
            Value = value;
        }

    }
}
