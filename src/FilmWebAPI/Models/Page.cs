using System;

namespace FilmWebAPI.Requests.Get
{
    public class Page
    {
        private readonly int _pageNo;
        private readonly int _pageSize;

        public Page(int pageNo, int pageSize)
        {
            if (pageNo < 0)
                throw new ArgumentOutOfRangeException(nameof(pageNo));

            if (pageSize < 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize));

            _pageNo = pageNo;
            _pageSize = pageSize;
        }

        public int GetPageBeginIndex()
        {
            return _pageNo * _pageSize;
        }

        public int GetPageEndIndex()
        {
            return (_pageNo + 1) * _pageSize;
        }
    }
}