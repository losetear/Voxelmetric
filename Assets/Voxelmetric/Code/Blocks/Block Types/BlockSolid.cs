using UnityEngine;
using System.Collections;

public class BlockSolid : BlockController
{

    public BlockSolid() : base() { }

    public override void AddBlockData(Chunk chunk, BlockPos pos, MeshData meshData, Block block)
    {
        if (!chunk.GetBlock(pos.Add(0, 1, 0)).controller.IsSolid(BlockDirection.down))
            BuildFace(chunk, pos, meshData, BlockDirection.up, block);

        if (!chunk.GetBlock(pos.Add(0, -1, 0)).controller.IsSolid(BlockDirection.up))
            BuildFace(chunk, pos, meshData, BlockDirection.down, block);

        if (!chunk.GetBlock(pos.Add(0, 0, 1)).controller.IsSolid(BlockDirection.south))
            BuildFace(chunk, pos, meshData, BlockDirection.north, block);

        if (!chunk.GetBlock(pos.Add(0, 0, -1)).controller.IsSolid(BlockDirection.north))
            BuildFace(chunk, pos, meshData, BlockDirection.south, block);

        if (!chunk.GetBlock(pos.Add(1, 0, 0)).controller.IsSolid(BlockDirection.west))
            BuildFace(chunk, pos, meshData, BlockDirection.east, block);

        if (!chunk.GetBlock(pos.Add(-1, 0, 0)).controller.IsSolid(BlockDirection.east))
            BuildFace(chunk, pos, meshData, BlockDirection.west, block);
    }

    public virtual void BuildFace(Chunk chunk, BlockPos pos, MeshData meshData, BlockDirection blockDirection, Block block)
    {
       
    }

    public override string Name() { return "solid"; }

    public override bool IsSolid(BlockDirection blockDirection) { return true; }
}