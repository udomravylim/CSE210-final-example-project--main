using System;


namespace Byui.Games.Casting
{
    /// <summary>
    /// A visible Actor.
    /// </summary>
    /// <remarks>
    /// The responsibility of Image is to define the image-based appearance of an Actor.
    /// </remarks>
    public class Image : Actor
    {
        private string[] _files = new string[] { String.Empty };
        private int _frame = 0;
        private int _index = 0;
        private int _keyFrame = 0;
        private bool _repeated = false;
        
        public Image() { }

        public virtual void Animate(string[] files, float duration, int frameRate)
        {
            Animate(files, duration, frameRate, true);
        }

        public virtual void Animate(string[] files, float duration, int frameRate, bool repeated)
        {
            _files = files;
            _keyFrame = (int) (duration * frameRate) / files.Length;
            _repeated = repeated;
        }

        public void Display(string file)
        {
            _files = new string[] { file };
        }

        public string GetFile()
        {
            _frame++;
            if (_frame >= _keyFrame)
            {
                _frame = 0;
                if (_repeated)
                {
                    _index = (_index + 1) % (_files.Length - 1);
                }
                else
                {
                    _index = Math.Min(_index + 1, _files.Length - 1);
                }
            }
            return _files[_index].Trim();
        }

    }
}