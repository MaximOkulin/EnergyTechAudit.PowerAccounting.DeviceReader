using EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Helpers
{
    public class ArchiveAddressMapHelper
    {
        public List<ArchiveAddress> ArchiveAddreses = new List<ArchiveAddress>();
        private bool _isLoop;

        public ArchiveAddressMapHelper(int maxArchiveRecord, int archiveRecordCount, int nextRecordIndex, DateTime nextRecordTime)
        {
            nextRecordIndex++; // по факту запишется в следующий адрес, т.к. индексы будущих записей идут в zero-base, а по факту
            // в нулевой записи лежит заголовок архивной записи

            if (nextRecordIndex > maxArchiveRecord)
            {
                nextRecordIndex = 1;
            }

            if (maxArchiveRecord == archiveRecordCount)
            {
                // архив закольцован
                _isLoop = true;
                for(int i = 1; i <= maxArchiveRecord; i++)
                {
                    ArchiveAddreses.Add(new ArchiveAddress(i, default(DateTime)));
                }
            }
            else if (archiveRecordCount < maxArchiveRecord)
            {
                // архив незакольцован
                _isLoop = false;
                for (int i = 1; i <= archiveRecordCount; i++)
                {
                    ArchiveAddreses.Add(new ArchiveAddress(i, default(DateTime)));
                }
            }

            var currentAddress = ArchiveAddreses.First(p => p.Index == nextRecordIndex);
            currentAddress.DateTime = nextRecordTime;

            var currentDate = currentAddress.DateTime;
            if (_isLoop)
            {
                for(int i = nextRecordIndex - 1; i >= 1; i--)
                {
                    var a = ArchiveAddreses.First(p => p.Index == i);
                    a.DateTime = currentDate.AddHours(-1);
                    currentDate = a.DateTime;
                }

                for(int i = maxArchiveRecord; i >= nextRecordIndex + 1; i--)
                {
                    var a = ArchiveAddreses.First(p => p.Index == i);
                    a.DateTime = currentDate.AddHours(-1);
                    currentDate = a.DateTime;
                }
            }
            else
            {
                for (int i = nextRecordIndex - 1; i >= 1; i--)
                {
                    var a = ArchiveAddreses.First(p => p.Index == i);
                    a.DateTime = currentDate.AddHours(-1);
                    currentDate = a.DateTime;
                }
            }
        }

        public int GetIndexByDate(DateTime dateTime)
        {
            int index = -1;
            var archiveAddress = ArchiveAddreses.FirstOrDefault(p => p.DateTime == dateTime);
            if (archiveAddress != null)
            {
                index = archiveAddress.Index;
            }

            return index;
        }
    }
}
