using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using DragAndDropWithAdorner.DragDropListBox;

namespace DragAndDropWithAdorner
{
    public class DragDropHelper
    {
        public Window ParentWindow { get; set; }
        public FrameworkElement DragSource { get; set; }
        public FrameworkElement DropTarget { get; set; }

        public Point OriginalPosition { get; set; }
        public Point OriginalOffset { get; set; }
        public FrameworkElement DraggedElement { get; set; }


        private DraggedAdorner _draggedAdorner;


        public DragDropHelper(Window parentWindow, FrameworkElement dragSource, FrameworkElement dropTarget)
        {
            ParentWindow = parentWindow;
            DragSource = dragSource;
            DropTarget = dropTarget;

            InitDragDrop();
        }

        public void StartDrag(MouseEventArgs e, FrameworkElement draggedElement)
        {
            OriginalPosition = e.GetPosition(DragSource);
            OriginalOffset = e.GetPosition(draggedElement);
            DraggedElement = draggedElement;

            CreateDraggedAdorner();
            UpdateDraggedAdornerPos(OriginalPosition);
        }

        public void StopDrag()
        {
            RemoveDraggedAdorner();
        }

        public void UpdateAdorner(DragEventArgs e, bool makeVisible = true)
        {
            var pos = e.GetPosition(DragSource);
            UpdateDraggedAdornerPos(pos, makeVisible);
        }


        private void InitDragDrop()
        {
            // make sure the drag/drop events below are properly fired
            ParentWindow.AllowDrop = true;

            // set up window events (drag scope)
            ParentWindow.DragEnter += TopWindow_OnDragEnter;
            ParentWindow.DragLeave += TopWindow_OnDragLeave;
            ParentWindow.DragOver += TopWindow_OnDragOver;

            // setup target list events
            DropTarget.DragEnter += DropTarget_OnDragEnter;
            DropTarget.DragLeave += DropTarget_OnDragLeave;
        }


        //
        // Adorner
        //


        // Creates or updates the dragged Adorner. 
        private void CreateDraggedAdorner()
        {
            if (_draggedAdorner == null)
            {
                var adornerLayer = AdornerLayer.GetAdornerLayer(DragSource);
                _draggedAdorner = new DraggedAdorner(DraggedElement, DragSource, adornerLayer);
            }
        }

        private void UpdateDraggedAdornerPos(Point currentPosition, bool makeVisible = false)
        {
            if (_draggedAdorner == null)
                return;

            var x = currentPosition.X - OriginalOffset.X;
            var y = currentPosition.Y - OriginalOffset.Y;
            _draggedAdorner.SetPosition(x, y);

            if (makeVisible)
            {
                ShowDraggedAdorner();
            }
        }

        private void ShowDraggedAdorner()
        {
            if (_draggedAdorner == null)
                return;

            _draggedAdorner.Visibility = Visibility.Visible;
        }

        private void HideDraggedAdorner()
        {
            if (_draggedAdorner == null)
                return;

            _draggedAdorner.Visibility = Visibility.Hidden;
        }

        private void RemoveDraggedAdorner()
        {
            if (_draggedAdorner == null)
                return;

            _draggedAdorner.Detach();
            _draggedAdorner = null;
        }



        //
        // Target list: bring Adorner Position up to date
        //

        private void DropTarget_OnDragEnter(object sender, DragEventArgs e)
        {
            UpdateAdorner(e);
            e.Handled = true;
        }

        private void DropTarget_OnDragLeave(object sender, DragEventArgs e)
        {
            UpdateAdorner(e);
            e.Handled = true;
        }

        //
        // Window: bring Adorner Position up to date
        //

        private void TopWindow_OnDragEnter(object sender, DragEventArgs e)
        {
            UpdateAdorner(e);

            // only reset drag drop effect if event was sent by the parent window
            if (e.Source == ParentWindow)
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }

        private void TopWindow_OnDragOver(object sender, DragEventArgs e)
        {
            UpdateAdorner(e);

            // only reset drag drop effect if event was not sent by the drop target
            if (e.Source != DropTarget)
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }

        private void TopWindow_OnDragLeave(object sender, DragEventArgs e)
        {
            // only hide the adorner if event was sent by the parent window
            if (e.Source == ParentWindow)
            {
                HideDraggedAdorner();
                e.Handled = true;
            }
        }
    }
}
