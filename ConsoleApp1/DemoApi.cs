using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class DemoApi
    {
        private IDemoBo _DemoBo;
        public DemoApi(IDemoBo demoBo)
        {
            _DemoBo = demoBo;
        }
        public void CreateDemo(int param1, int param2)
        {
            if (param1 == 0)
            {
                throw new Exception("Param1 is zero");
            }
            if (param2 == 0)
            {
                throw new Exception("Param2 is zero");
            }
            if (param1 == param2)
            {
                throw new Exception("Param1 and param2 are equal");
            }
            _DemoBo.CreateDemo(param1);
        }
    }

    public class DemoBo : IDemoBo
    {
        private IDemoDao _DemoDao;

        public DemoBo(IDemoDao demoDao)
        {
            _DemoDao = demoDao;
        }
        public void CreateDemo(int param1)
        {
            if (param1 < 5000)
            {
                _DemoDao.CreateDemo();
            }
        }
    }

    public class DemoDao : IDemoDao
    {
        public void CreateDemo()
        {
            ///
        }
    }

    public interface IDemoBo
    {
        void CreateDemo(int param1);
    }

    public interface IDemoDao
    {
        void CreateDemo();
    }
}
