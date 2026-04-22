using System;
using System.Collections.Generic;
using System.Text;

namespace Cantask.Services
{
    public enum DockZone     {
        Left, 
        Center, 
        Right, 
        RightTop, 
        RightBottom, 
        Floating
    }
    public class WindowModel
    {
        public int Id {  get; set; }
        public string Title { get; set; } = "";
        public DockZone Zone { get; set; } = DockZone.Left;

        //Posicion cuando es flotante
        public double X { get; set; } = 100;
        public double Y { get; set; } = 100;
        public double Width { get; set; } = 320;
        public double Height { get; set; } = 240;
        public bool IsFloating => Zone == DockZone.Floating;

    }
    public class WindowService
    {
        private int _nextId = 1;
        private readonly List<WindowModel> _windows = new();

        public IReadOnlyList<WindowModel> Windows => _windows;

        public event Action? OnChange;

        public void OpenWindow()
        {
            _windows.Add(new WindowModel
            {
                Id = _nextId,
                Title = $"NUEVA VENTANA {_nextId}",
                Zone = DockZone.Left
            });
            _nextId++;
            OnChange?.Invoke();
        }
        public void CloseWindow(int id)
        {
            var w = _windows.FirstOrDefault(w => w.Id == id);
            if (w is not null)
            {
                _windows.Remove(w);
                OnChange?.Invoke();
            }

        }
        public void DockWindow(int id, DockZone zone)
        {
            var w = _windows.FirstOrDefault(w => w.Id == id);
            if (w is null) return;
            w.Zone = zone;
            OnChange?.Invoke();
        }
        public void FloatWindow(int id, double x, double y)
        {
            var w = _windows.FirstOrDefault(w => w.Id == id);
            if (w is null) return;
            w.Zone = DockZone.Floating;
            w.X = x;
            w.Y = y;
            OnChange?.Invoke();
        }
        public void UpdatePosition(int id, double x, double y)
        {
            var w = _windows.FirstOrDefault(w => w.Id == id);
            if (w is null) return;
            w.X = x;
            w.Y = y;
           
        }
    }
}
