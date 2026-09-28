using Il2Cpp;

namespace ProbablyNuclear
{
    class ModLockHandler
    {
        public static void TryOpenLock(GameItem key, GameItem box, string keyLockId)
        {
            if (LockHelper.IsCurrentlyLocked(box))
            {
                EmporiumAudioPlayer.Instance.audioClickClick.Play();
                key.Destroy();
                LockHelper.UnlockContainer(box);
            }
        }
    }
}
