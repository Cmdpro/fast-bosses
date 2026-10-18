using MioGame;
using MioModdingApi;
using MioModLoader;
using PolyHook2.API;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace TestMod
{
    public class FastBossesMod : Mod
    {
        public int speed = 2;
        public override void Initialize()
        {
            Hooks();
        }
        private unsafe void Hooks()
        {
            On.MioGame.On_Rambo.update.Hook += (orig, self, n) => MultUpdate(self->boss_sm, () => orig(self, n));
            On.MioGame.On_The_Project.update.Hook += (orig, self, n) => MultUpdate(self->sm, () => orig(self, n));
            On.MioGame.On_Centrifugy.update.Hook += (orig, self, n) => MultUpdate(self->sm, () => orig(self, n));
            On.MioGame.On_Saw_Longue.update.Hook += (orig, self, n) => MultUpdate(self->sm, () => orig(self, n));
            On.MioGame.On_Sasuke.update.Hook += (orig, self, n) => MultUpdate(self->sm, () => orig(self, n));
            On.MioGame.On_Blacksmith.update.Hook += (orig, self, n) => MultUpdate(self->sm, () => orig(self, n));
            On.MioGame.On_Crabash_boss.update.Hook += (orig, self, n) => MultUpdate(self->boss_sm, () => orig(self, n));
            On.MioGame.On_Hodoor.update.Hook += (orig, self, n) => MultUpdate(self->main_sm, () => orig(self, n));
            On.MioGame.On_Twin_hornfell.update.Hook += (orig, self, n) => MultUpdate(self->main_sm, () => orig(self, n));
            On.MioGame.On_Zangy.update.Hook += (orig, self, n) => MultUpdate(self->sm, () => orig(self, n));
            On.MioGame.On_Petit_trapu.update.Hook += (orig, self, n) => MultUpdate(self->sm, () => orig(self, n));
            On.MioGame.On_Twin_crabash.update.Hook += (orig, self, n) => MultUpdate(self->boss_sm, () => orig(self, n));
            On.MioGame.On_Shii_boss.update.Hook += (orig, self, n) => MultUpdate(self->boss_sm, () => orig(self, n));
            On.MioGame.On_Scarecrow.update.Hook += (orig, self, n) => MultUpdate(self->sm, () => orig(self, n));
            On.MioGame.On_Vine_monster.update.Hook += (orig, self, n) => MultUpdate(self->sm, () => orig(self, n));
            On.MioGame.On_Bamby.update.Hook += (orig, self, n) => MultUpdate(self->sm, () => orig(self, n));
            On.MioGame.On_Simole.update.Hook += (orig, self, n) => MultUpdate(self->sm, () => orig(self, n));
            On.MioGame.On_Spidy.update.Hook += (orig, self, n) => MultUpdate(self->sm, () => orig(self, n));
        }

        private unsafe void MultUpdate(Boss_state_machine? sm, System.Action orig)
        {
            orig();
            if (sm == null || Util.MioStringToString(sm.Value.state) != "intro")
            {
                for (int i = 1; i < speed; i++)
                {
                    orig();
                }
            }
        }
    }
}
