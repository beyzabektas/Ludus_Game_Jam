using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static void PlayAnimation<T>(T _animator, string _animationKey) where T : Animator => _animator.Play(GetStringToHash(_animationKey));
    private static int GetStringToHash(string _key) => Animator.StringToHash(_key);
}