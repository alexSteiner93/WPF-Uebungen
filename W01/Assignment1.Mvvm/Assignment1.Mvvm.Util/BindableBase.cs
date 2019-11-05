using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Assignment1.Mvvm.Util
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// updates the backing field's value of the given property and
        /// informs all observers if the value changed
        /// </summary>
        /// <typeparam name="T">the type of the property that changes</typeparam>
        /// <param name="storage">a reference to the backing field of the property</param>
        /// <param name="value">the new value of the property</param>
        /// <param name="name">the name of the property as a string (is automatically added by the compiler if omitted)</param>
        /// <param name="additionalPropertyNames">names of other properties that change along with this property</param>
        /// <returns>true if the property value changed (= is not the same as before), false otherwise</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string name = null, params string[] additionalPropertyNames)
        {
            if (Equals(storage, value))
            {
                // no need to inform anyone, new value is the same as the old one, no change
                return false;
            }

            // update the backing field's value (which is passed to this method by reference)
            storage = value;

            // inform the ui about the changed value of the given property
            OnPropertyChanged(name);

            if (additionalPropertyNames?.Any() == true)
            {
                // inform the ui about other properties that changed along the
                // way of changing the given property, in order to update the
                // ui accordingly
                foreach (var p in additionalPropertyNames)
                {
                    OnPropertyChanged(p);
                }
            }

            // signal that the property value actually changed
            return true;
        }

        /// <summary>
        /// informs all observers about a change in the property with the given name
        /// </summary>
        /// <param name="name">the name of the changed property as a string</param>
        protected void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
