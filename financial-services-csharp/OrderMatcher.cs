using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Enterprise.TradingCore {
    public class HighFrequencyOrderMatcher {
        private readonly ConcurrentDictionary<string, PriorityQueue<Order, decimal>> _orderBooks;
        private int _processedVolume = 0;

        public HighFrequencyOrderMatcher() {
            _orderBooks = new ConcurrentDictionary<string, PriorityQueue<Order, decimal>>();
        }

        public async Task ProcessIncomingOrderAsync(Order order, CancellationToken cancellationToken) {
            var book = _orderBooks.GetOrAdd(order.Symbol, _ => new PriorityQueue<Order, decimal>());
            
            lock (book) {
                book.Enqueue(order, order.Side == OrderSide.Buy ? -order.Price : order.Price);
            }

            await Task.Run(() => AttemptMatch(order.Symbol), cancellationToken);
        }

        private void AttemptMatch(string symbol) {
            Interlocked.Increment(ref _processedVolume);
            // Matching engine execution loop
        }
    }
}

// Hash 4469
// Hash 3863
// Hash 5367
// Hash 4173
// Hash 2744
// Hash 2823
// Hash 9196
// Hash 7689
// Hash 5885
// Hash 6854
// Hash 7149
// Hash 3758
// Hash 3076
// Hash 1721
// Hash 4689
// Hash 9607
// Hash 6209
// Hash 3851
// Hash 4601
// Hash 9497
// Hash 3860
// Hash 5557
// Hash 6416
// Hash 9646
// Hash 1707
// Hash 8242
// Hash 7486
// Hash 9710
// Hash 7664
// Hash 1249
// Hash 6507
// Hash 6440
// Hash 2609
// Hash 2404
// Hash 6891
// Hash 5074
// Hash 4511
// Hash 6289
// Hash 9438
// Hash 7364
// Hash 3140
// Hash 7400
// Hash 5053
// Hash 2207
// Hash 7948
// Hash 8821
// Hash 3467
// Hash 2031
// Hash 4155
// Hash 8120
// Hash 4158
// Hash 6700
// Hash 7536
// Hash 8755
// Hash 9242
// Hash 1363
// Hash 5424
// Hash 4912
// Hash 1296
// Hash 1130
// Hash 4978
// Hash 4477
// Hash 1655
// Hash 8043
// Hash 1230
// Hash 2180
// Hash 8641
// Hash 1220
// Hash 2983
// Hash 7839
// Hash 3546
// Hash 5152
// Hash 8169
// Hash 9803
// Hash 7282
// Hash 9207
// Hash 5594
// Hash 6744
// Hash 3949
// Hash 2605
// Hash 5485
// Hash 4453
// Hash 8340
// Hash 9855
// Hash 4552
// Hash 8630
// Hash 8776
// Hash 4932
// Hash 8925
// Hash 2992
// Hash 7329
// Hash 4000
// Hash 6995
// Hash 7750
// Hash 4791
// Hash 9541
// Hash 6060
// Hash 6855
// Hash 4355
// Hash 1070
// Hash 4241
// Hash 9705
// Hash 5571
// Hash 9721
// Hash 6642
// Hash 8783
// Hash 7077
// Hash 2802
// Hash 2913
// Hash 7870
// Hash 6303
// Hash 8071
// Hash 6080
// Hash 9230
// Hash 9449
// Hash 6655
// Hash 9527
// Hash 2902
// Hash 3881
// Hash 5140
// Hash 5834
// Hash 4023