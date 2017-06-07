using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFrameWork
{
    public class BaseViewModel : NotifyObject, IDisposable
    {
        private BaseViewModel _parent;
        private string _title;

        public BaseViewModel Parent
        {
            get
            {
                return _parent;
            }

            set
            {
                _parent = value;
                OnPropertyChanged("Parent");
            }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        protected BaseViewModel(BaseViewModel parent = null, string title = null)
        {
            Parent = parent;
            Title = title;
        }

        public virtual void Dispose()
        {
        }
    }
}
