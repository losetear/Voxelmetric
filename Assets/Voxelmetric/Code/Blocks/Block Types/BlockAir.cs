using UnityEngine;
using System.Collections;

public class BlockAir : BlockController
{

    public BlockAir() : base() { }

    public override bool IsSolid(BlockDirection blockDirection) { return false; }

    public override string Name() { return "air"; }

    public override bool IsTransparent() { return true; }
}   