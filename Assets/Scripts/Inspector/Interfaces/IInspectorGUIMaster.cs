using UnityEngine;
using VEngine.Items;

namespace VEngine.Inspector
{
    public interface IInspectorMaster 
    {
        void Open(bool open);

        void Inspect(IItem item);
        void Detach();
    }
}
