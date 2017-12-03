using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DragAndDropWithAdorner
{
    namespace DragDropListBox
    {
        /// <summary>
        /// adorner to visualize a dragged element with a bitmap copy shown below the mouse cursor
        /// </summary>
        public class DraggedAdorner : Adorner
        {
            private readonly Visual _clone;
            private readonly AdornerLayer _adornerLayer;
            private double _left;
            private double _top;


            /// <summary>
            /// constructor
            /// </summary>
            /// <param name="draggedItem">the dragged item</param>
            /// <param name="adornedElement">the parent element of the dragged item, e.g. a list box</param>
            /// <param name="adornerLayer">the adordner layer in which to place this adorner</param>
            public DraggedAdorner(FrameworkElement draggedItem, FrameworkElement adornedElement, AdornerLayer adornerLayer)
                : base(adornedElement)
            {
                _adornerLayer = adornerLayer;
                _clone = CopyElementToBitmap(draggedItem);                
                _adornerLayer.Add(this);

                // take out of hit test tree or you get flickering!
                IsHitTestVisible = false;
            }

            /// <summary>
            /// draws the given source element into a bitmap
            /// </summary>
            /// <param name="source"></param>
            /// <returns></returns>
            public static Visual CopyElementToBitmap(FrameworkElement source)
            {
                var w = source.ActualWidth;
                var h = source.ActualHeight;
                var bmp = new RenderTargetBitmap((int)Math.Round(w), (int)Math.Round(h), 96, 96, PixelFormats.Default);
                var dv = new DrawingVisual();
                using (var dc = dv.RenderOpen())
                {
                    var vb = new VisualBrush(source);
                    dc.DrawRectangle(vb, null, new Rect(new Point(), new Size(w, h)));
                }
                bmp.Render(dv);
                return dv;
            }

            /// <summary>
            /// updates the position of the adorner relative to the original position
            /// </summary>
            /// <param name="left"></param>
            /// <param name="top"></param>
            public void SetPosition(double left, double top)
            {
                // -1 and +13 align the dragged adorner with the dashed rectangle that shows up
                // near the mouse cursor when dragging.
                _left = left /*- 1*/;
                _top = top /*13*/;
                if (_adornerLayer != null)
                {
                    _adornerLayer.Update(AdornedElement);
                }
            }

            protected override Visual GetVisualChild(int index)
            {
                return _clone;
            }

            protected override int VisualChildrenCount
            {
                get { return 1; }
            }

            public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
            {
                // make sure that the visual clone of the original dragged element is
                // correctly translated
                GeneralTransformGroup result = new GeneralTransformGroup();
                result.Children.Add(base.GetDesiredTransform(transform));
                result.Children.Add(new TranslateTransform(_left, _top));

                return result;
            }

            public void Detach()
            {
                _adornerLayer.Remove(this);
            }

        }
    }
}
