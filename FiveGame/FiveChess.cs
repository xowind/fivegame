using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace FiveGame
{
    struct step :IComparable<step>
    {
        public int i,j,sc;

        int IComparable<step>.CompareTo(step other)
        {
            return this.sc - other.sc;
        }
    }
    class FiveChess
    {
        private const int bsize=15;
        private const int inf = 1 << 28;       

        private int[][] board;
        private int nextI,nextJ;

        public const int WITHE = 2;
        public const int BLACK = 1;
        public int maxStep;
        public bool AIFirst;
        public int AIColor,UserColor;

        private static int[] h= null;
        private static int[] msk;

        private Stack<step> history;
        private Stack<step> nextSteps;
        private step stp;
        private const int spanDgree = 15;
        private static int[] fmult;

        public FiveChess(int hardness, bool AIFirst)
        {
            this.maxStep = hardness * 2;
            this.AIFirst = AIFirst;
            this.AIColor = AIFirst ? BLACK : WITHE;
            this.UserColor = !AIFirst ? BLACK : WITHE;
            init();
        }
        public void init()
        {
            nextI = nextJ = 0;
            board = new int[bsize+8][];
            for (int i = 0; i < bsize+8; ++i)
                board[i] = new int[bsize+8];
            for (int i = 0; i < bsize+8; i++)
                for (int j = 0; j < bsize+8; j++)
                    board[i][j] = 3;
            for (int i = 4; i < bsize + 4; i++)
                for (int j = 4; j < bsize + 4; j++)
                    board[i][j] = 0;
            history = new Stack<step>();
            nextSteps = new Stack<step>();
            if (h == null)
            {
                h= new int[65560];
                for(int i=0;i<65560;i++){
                    h[i] = 0;
                }
                fmult = new int[20];
                for (int i = 1; i < 20; i++)
                {
                    fmult[i] = 100000 * i;
                }
                initScores();
                msk = new int[4];
                msk[0] = 0;
                msk[3] = 3;
                msk[1] = 2;
                msk[2] = 1;
            }
        }
        unsafe private int move(int n, int c)
        {
            c<<=1;
            if (c > 0)
            {
                n <<= c;
                n |= (1 << c) - 1;
            }
            else if(c<0)
            {
                c = -c;
                n >>= c;
                c= 16 - c;
                n |= ~((1 << c) - 1);
            }
            return n;
        }
        unsafe private int gen(int n, int i)
        {
            int high = move(n, 3 - i)&0xFF00;
            int low = move(n, 4 - i) & 0xFF;
            return high | low;
        }
        private void sol(string s,int score)
        {
            int so; 
            int sm,mk,mks;
            so = sm = 0xFFFF;
            int i,g,gs;
            int len = s.Length;
            for(i=len-1;i>=0;i--)
            {
                so <<= 2;
                sm <<= 2;
                if (s[i] == 'o') 
                {
                    so |= BLACK;
                }
            }
            so &= 0xFFFF;
            sm &= 0xFFFF;
            for (i= 0; i < len; i++)
            {
                if (s[i] == 'o'){
                    int t = g = gen(so, i);
                    int tm = mk = ~gen(sm, i)&0xFFFF;
                    gs = mks = 0;
                    for (int j = 0; j < 8; ++j)
                    {
                        gs<<=2;
                        mks <<= 2;
                        gs |= t & 3;
                        mks |= tm & 3;
                        t >>= 2;
                        tm >>= 2;
                    }
                    for (int j = 0; j < 65536; ++j)
                    {
                        if ((mk & g) == (mk & j) || (mks & gs) == (mks & j))
                        {
                            h[j] = score;
                        }

                    }
                }
            }
        }
        private void initScores()
        {
            sol("o..", 2);
            sol("...o...", 10);

            sol("oo...", 50);
            sol("o.o..", 50);
            sol("o..o.", 50);
            sol("o...o", 50);
            sol(".oo..", 50);
            sol(".o.o.", 50);

            sol("..ooo", 200);
            sol(".o.oo", 200);
            sol(".oo.o", 200);
            sol(".ooo.", 200);
            sol("o..oo", 200);
            sol("o.o.o", 200);

            sol("..o.o.", 300);
            sol("...oo..", 350);
            sol(".o..o.", 350);
            sol("..o.o..", 400);
            sol("...oo...", 450);

            sol(".ooo..", 5000);
            sol("..ooo..", 7000);
            sol(".o.oo.", 8000);

            sol("o.ooo", 10000);
            sol("oo.oo", 10000);
            sol(".oooo", 10000);

            sol(".oooo.", 100000);

            sol("ooooo", 5000000);
            #region
            /*
            //sol("o..", 4);
            //sol("...o...", 20);

            //sol("oo...", 100);
            //sol("o.o..", 100);
            //sol("o..o.", 100);
            //sol("o...o", 100);
            //sol(".oo..", 100);
            //sol(".o.o.", 100);

            //sol("..ooo", 500);
            //sol(".o.oo", 500);
            //sol(".oo.o", 500);
            //sol(".ooo.", 500);
            //sol("o..oo", 500);
            //sol("o.o.o", 500);

            //sol("..o.o.", 600);
            //sol("...oo..", 700);
            //sol(".o..o.", 700);
            //sol("..o.o..", 800);
            //sol("...oo...", 900);

            //sol(".ooo..", 8000);
            //sol("..ooo..", 9000);
            //sol(".o.oo.", 10000);

            //sol("o.ooo", 12000);
            //sol("oo.oo", 12000);
            //sol(".oooo", 12000);

            //sol(".oooo.", 50000);


            //sol("o...", 10);
            //sol("oo...", 150);
            //sol(".o..o.", 200);
            //sol("..o.o..", 250);
            //sol("ooo..", 500);
            //sol("o.o.o", 550);
            //sol("o..oo", 600);
            //sol("...oo...", 650);
            //sol("o.o.o", 700);
            //sol(".o.oo.", 800);
            //sol("oooo.", 2500);
            //sol("oo.oo", 2600);
            //sol("..ooo..", 3000);
            //sol("ooo.o", 3000);
            //sol(".oooo.",300000);

            sol("ooooo", 5000000);
 * 
 */
#endregion
        }

        /*
        private int evalue()
        {
            int ret=0;
            int g1, g2, g3, g4;
            int cnt = 2;
            foreach (step stp in steps)
            {
                if (cnt-- == 0)
                    break;
                int i = stp.i, j = stp.j;
                g1 = g2 = g3 = g4 = 0;
                if (board[i][j] != BLACK)
                {
                    for (int l = -4; l < 5; l++)
                    {
                        if (l == 0) continue;
                        g1 <<= 2;
                        g1 |= msk[board[i + l][j]] & 0x3;
                        g2 <<= 2;
                        g2 |= msk[board[i + l][j + l]] & 0x3;
                        g3 <<= 2;
                        g3 |= msk[board[i][j + l]] & 0x3;
                        g4 <<= 2;
                        g4 |= msk[board[i - l][j + l]] & 0x3;
                    }
                    ret += h[g1] + h[g2] + h[g3] + h[g4];
                }
                else
                {
                    for (int l = -4; l < 5; l++)
                    {
                        if (l == 0) continue;
                        g1 <<= 2;
                        g1 |= board[i + l][j] & 0x3;
                        g2 <<= 2;
                        g2 |= board[i + l][j + l] & 0x3;
                        g3 <<= 2;
                        g3 |= board[i][j + l] & 0x3;
                        g4 <<= 2;
                        g4 |= board[i - l][j + l] & 0x3;
                    }
                    ret -=h[g1] + h[g2] + h[g3] + h[g4];
                }
            }
            return AIFirst?-ret:ret;
        }*/

        unsafe private int evaluePo(int i, int j, int color)
        {
            int g1, g2, g3, g4;
            g1 = g2 = g3 = g4 = 0;
            if (color != BLACK)
            {
                for (int l = -4; l < 5; l++)
                {
                    if (l == 0) continue;
                    g1 <<= 2;
                    g1 |= msk[board[i + l][j]] & 0x3;
                    g2 <<= 2;
                    g2 |= msk[board[i + l][j + l]] & 0x3;
                    g3 <<= 2;
                    g3 |= msk[board[i][j + l]] & 0x3;
                    g4 <<= 2;
                    g4 |= msk[board[i - l][j + l]] & 0x3;
                }
                return h[g1] + h[g2] + h[g3] + h[g4];
            }
            else
            {
                for (int l = -4; l < 5; l++)
                {
                    if (l == 0) continue;
                    g1 <<= 2;
                    g1 |= board[i + l][j] & 0x3;
                    g2 <<= 2;
                    g2 |= board[i + l][j + l] & 0x3;
                    g3 <<= 2;
                    g3 |= board[i][j + l] & 0x3;
                    g4 <<= 2;
                    g4 |= board[i - l][j + l] & 0x3;
                }
                return h[g1] + h[g2] + h[g3] + h[g4];
            }
        }

        public void rollback()
        {
            if (history.Count >= 2)
            {
                stp = history.Pop();
                board[stp.i][stp.j] = 0;
                stp = history.Pop();
                board[stp.i][stp.j] = 0;
            }
        }

        unsafe private int span()
        {
            int sc,hi,nhi,ret=0;
            stp.i=stp.j=stp.sc=-inf;
            step[] heap = new step[spanDgree+1];
            for(int i=0;i<=spanDgree;i++)
                heap[i]=stp;
            for (int i = 4; i < bsize + 4; i++)
            {
                for (int j = 4; j < bsize + 4; j++)
                {
                    if(board[i][j]==0){
                        sc = Math.Max(evaluePo(i,j,AIColor),evaluePo(i,j,UserColor));
                        if (sc > heap[1].sc)
                        {
                            ret++;
                            heap[1].i = i;
                            heap[1].j = j;
                            heap[1].sc = sc;
                            hi=1;
                            while (hi <= (spanDgree>>1))
                            {
                                if (heap[hi << 1].sc < heap[(hi << 1) + 1].sc)
                                    nhi = hi << 1;
                                else
                                    nhi = (hi << 1) + 1;
                                if (heap[hi].sc > heap[nhi].sc)
                                {
                                    stp = heap[hi];
                                    heap[hi] = heap[nhi];
                                    heap[nhi] = stp;
                                    hi = nhi;
                                }
                                else
                                    break;
                            }
                        }
                    }
                }
            }
            ret = Math.Min(spanDgree, ret);
            ////int k = -1;
            ////if (k == 0)
            ////    Debug.WriteLine("New Debug");
            //for (int i = 1; i <= ret; i++)
            //{
            //    nextSteps.Push(heap[i]);
            //    //if (k == 0)
            //    //    Debug.WriteLine("{0} {1} {2}", heap[i].i, heap[i].j, heap[i].sc);
            //}

            Array.Sort<step>(heap);
            for (int i = 1; i <= ret; i++)
            {
                nextSteps.Push(heap[i]);
            }

            //for (int i = ret; i > 0; i--)
            //{
            //    nextSteps.Push(heap[1]);
            //    heap[1] = heap[ret];
            //    heap[ret].sc = inf;
            //    hi = 1;
            //    while (hi <= (ret >> 1))
            //    {
            //        if (heap[hi << 1].sc < heap[(hi << 1) + 1].sc)
            //            nhi = hi << 1;
            //        else
            //            nhi = (hi << 1) + 1;
            //        if (heap[hi].sc > heap[nhi].sc)
            //        {
            //            stp = heap[hi];
            //            heap[hi] = heap[nhi];
            //            heap[nhi] = stp;
            //            hi = nhi;
            //        }
            //        else
            //            break;
            //    }
            //}
            return ret;
        }

        unsafe private int evalue()
        {
            int max=-inf, min=-inf;
            for (int i = 4; i < bsize + 4; i++)
            {
                for (int j = 4; j < bsize + 4; j++)
                {
                    if (board[i][j] == AIColor)
                    max=Math.Max(max,evaluePo(i,j,AIColor));
                    if(board[i][j]==UserColor)
                    min=Math.Max(min,evaluePo(i,j,UserColor));
                }
            }
            return max - min;
        }

        public int getBoard(int X, int Y)
        {
            return board[Y + 4][X + 4];
        }
        public void start(out int X, out int Y)
        {
            X = Y = 7;
            if (AIFirst) board[4 + Y][4 + X] = BLACK;
        }
        public int playNext(out int X,out int Y,int preX,int preY)
        {
            X = Y = 0;
            board[4 + preY][4 + preX] = UserColor;
            stp.i=4 + preY;
            stp.j=4 + preX;
            history.Push(stp);
            if (evaluePo(4 + preY, 4 + preX, UserColor) > 100000 * 4) return -1;
            MaxDfs(maxStep, inf);
            stp.i = nextI;
            stp.j = nextJ;
            history.Push(stp);
            X = nextJ - 4;
            Y = nextI - 4;
            board[4 + Y][4 + X] = AIColor;
            if (evaluePo(4 + Y, 4 + X, AIColor) > 100000 * 4) return 1;
            return 0;
        }

        unsafe private int MaxDfs(int steplef, int b)
        {
            int a=-inf;
            int na,i,j;
            int sn = span();
            while (sn-- > 0)
            {
                stp = nextSteps.Pop();
                if (a < b)
                {
                    i = stp.i;
                    j = stp.j;
                    //if (i == 11 && j == 11 && steplef == maxStep)
                    //{
                    //    i = i;
                    //}
                    board[i][j] = AIColor;
                    if (evaluePo(i, j, AIColor) > 100000 * 4)
                        na = fmult[ steplef];
                    else if (steplef == 1)
                        na = evalue();
                    else
                    {
                        na = MinDfs(steplef - 1, a);
                        //if (steplef == maxStep)
                        //{
                        //    i = i;
                        //}
                    }
                    board[i][j] = 0;
                    if (na > a)
                    {
                        a = na;
                        if (steplef == maxStep)
                        {
                            nextI = i;
                            nextJ = j;
                        }
                    }
                }
            }
            return a;
        }
        unsafe private int MinDfs(int steplef, int a)
        {
            int b = inf;
            int nb,i,j;
            int sn = span();
            while (sn-- > 0)
            {
                stp = nextSteps.Pop();
                if (a < b)
                {
                    i = stp.i;
                    j = stp.j;
                    //if (i == 13 && j == 8)
                    //{
                    //    i = i;
                    //}
                    board[i][j] = UserColor;
                    if (evaluePo(i, j, UserColor) > 100000 * 4)
                        nb = - fmult[ steplef];
                    else if (steplef == 1)
                        nb = evalue();
                    else
                        nb = MaxDfs(steplef - 1, b);
                    if (nb < b)
                        b = nb;
                    board[i][j] = 0;
                }
            }
            return b;
        }


        /*
        private int MaxDfs(int steplef, int b)
        {
            int a=-inf;
            int na;
            //step stp = steps.Peek();
            int si, ti, sj, tj;
            si = 4; ti = bsize + 3;
            sj = 4; tj = bsize + 3;
            //si = Math.Max(4, stp.i - 4);
            //ti = Math.Min(bsize + 3, stp.i + 4);
            //sj = Math.Max(4, stp.j - 4);
            //tj = Math.Min(bsize + 3, stp.j + 4);
            for (int i = si; i <= ti; ++i)
            {
                for (int j = sj; j <= tj; ++j)
                {
                    if (board[i][j] == 0)
                    {
                        //if (i == 11 && j == 10 && steplef == maxStep)
                        //{
                        //    board[i][j] = AIColor;
                        //}
                        //if (i == 11 && j == 10)
                        //{
                        //    board[i][j] = AIColor;
                        //}
                        board[i][j] = AIColor;
                        //stp.i=i;
                        //stp.j=j;
                        //steps.Push(stp);
                        if (steplef == 1)
                            na = evalue();
                        else
                            na =  MinDfs(steplef - 1, a);
                        //steps.Pop();
                        board[i][j] = 0;
                        if (na > a)
                        {
                            a = na;
                            if (steplef == maxStep)
                            {
                            nextI = i;
                            nextJ = j;
                            }
                        }
                        if (a >= b)
                            return a;
                    }
                }
            }
            return a;
        }
        private int MinDfs(int steplef, int a)
        {
            int b = inf;
            int nb;
            //step stp = steps.Peek();
            int si, ti, sj, tj;
            si = 4; ti = bsize + 3;
            sj = 4; tj = bsize + 3;
            //si = Math.Max(4, stp.i - 4);
            //ti = Math.Min(bsize + 3, stp.i + 4);
            //sj = Math.Max(4, stp.j - 4);
            //tj = Math.Min(bsize + 3, stp.j + 4);
            for (int i = si; i <= ti; ++i)
            {
                for (int j = sj; j <= tj; ++j)
                {
                    if (board[i][j] == 0)
                    {
                        if (i == 7 && j == 6)
                        {
                            board[i][j] = UserColor;
                        }
                        board[i][j] = UserColor;
                        //stp.i = i;
                        //stp.j = j;
                        //steps.Push(stp);
                        if (steplef == 1)
                            nb = evalue();
                        else
                            nb =  MaxDfs(steplef - 1, b);
                        if (nb < b)
                        {
                            b = nb;
                        }
                        //steps.Pop();
                        board[i][j] = 0;
                        if (b <= a)
                            return b;
                    }
                }
            }
            return b;
        }
         */
    }
}
