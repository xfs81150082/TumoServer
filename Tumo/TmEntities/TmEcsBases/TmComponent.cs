using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public abstract class TmComponent : TmEcsBase
    {
        public TmEntity Parent { get; set; }
        public override void TmAwake()
        {
            TmDictionary.Components.Add(EcsId, this);
        }
        public override void TmDispose()
        {
            base.TmDispose();
            TmDictionary.Components.Remove(EcsId);
            try
            {
                if (Parent != null)
                {
                    TmComponent tm;
                    Parent.Components.TryGetValue(this.GetType().Name, out tm);
                    if (tm != null)
                    {
                        Parent.Components.Remove(this.GetType().Name);
                    }
                    Parent = null;
                }
                //Console.WriteLine(TmTimerTool.CurrentTime() + " EcsId:" + EcsId + " TmComponent释放资源");
            }
            catch (Exception ex)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " ex:" + ex.Message + " TmComponent释放资源异常...");
            }
        }
    }
}
