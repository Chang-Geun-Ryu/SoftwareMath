using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab6
{
    public class Recyclebot
    {
        private List<Item> mRecycleItems;
        private List<Item> mNonRecycleItems;

        public List<Item> RecycleItems
        {
            get
            {
                return mRecycleItems;
            }
        }

        public List<Item> NonRecycleItems
        {
            get
            {
                return NonRecycleItems;
            }
        }

        public Recyclebot()
        {
            mRecycleItems = new List<Item> { };
            mNonRecycleItems = new List<Item> { };
        }

        // (1) 만약 아이템이 종이(paper), 가구(furniture) 또는 전기제품(electronics)이라면, 그 아이템의 무게는 5kg 미만이고 2kg 이상이다.
        public void Add(Item item)
        {
            if (item.Type == EType.Paper || item.Type == EType.Furniture || item.Type == EType.Electronics)
            {
                if (item.Weight < 5 && item.Weight >= 2)
                {
                    this.mRecycleItems.Add(item);
                    return;
                }
            }

            this.mNonRecycleItems.Add(item);

        }

        // (2) 아이템의 부피가 10L, 11L 또는 15L가 아니다.
        // 이는 그 아이템이 유독 폐기물임을 함의한다.
        // 이는 다시 그 아이템이 가구나 전기제품임을 함의한다.
        public List<Item> Dump()
        {
            var result = this.mNonRecycleItems.Where(p => p.Volume == 10 || p.Volume == 11 || p.Volume == 15);

            return this.mNonRecycleItems;
        }
    }
}
