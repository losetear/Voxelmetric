using UnityEngine;
using System;

[Serializable]
public static class BlockBuilder
{
    public static void BuildRenderer(Chunk chunk, BlockPos pos, MeshData meshData, BlockDirection blockDirection)
    {
        AddQuadToMeshData(chunk, pos, meshData, blockDirection, false);
    }

    public static void BuildCollider(Chunk chunk, BlockPos pos, MeshData meshData, BlockDirection blockDirection)
    {
        AddQuadToMeshData(chunk, pos, meshData, blockDirection, true);
    }

    public static void BuildColors(Chunk chunk, BlockPos pos, MeshData meshData, BlockDirection blockDirection)
    {
        bool nSolid = false;
        bool eSolid = false;
        bool sSolid = false;
        bool wSolid = false;

        bool wnSolid = false;
        bool neSolid = false;
        bool esSolid = false;
        bool swSolid = false;

        float light = 0;

        switch (blockDirection)
        {
            case BlockDirection.up:
                nSolid = chunk.GetBlock(pos.Add(0, 1, 1)).controller.IsSolid(BlockDirection.south);
                eSolid = chunk.GetBlock(pos.Add(1, 1, 0)).controller.IsSolid(BlockDirection.west);
                sSolid = chunk.GetBlock(pos.Add(0, 1, -1)).controller.IsSolid(BlockDirection.north);
                wSolid = chunk.GetBlock(pos.Add(-1, 1, 0)).controller.IsSolid(BlockDirection.east);

                wnSolid = chunk.GetBlock(pos.Add(-1, 1, 1)).controller.IsSolid(BlockDirection.east) && chunk.GetBlock(pos.Add(-1, 1, 1)).controller.IsSolid(BlockDirection.south);
                neSolid = chunk.GetBlock(pos.Add(1, 1, 1)).controller.IsSolid(BlockDirection.south) && chunk.GetBlock(pos.Add(1, 1, 1)).controller.IsSolid(BlockDirection.west);
                esSolid = chunk.GetBlock(pos.Add(1, 1, -1)).controller.IsSolid(BlockDirection.west) && chunk.GetBlock(pos.Add(1, 1, -1)).controller.IsSolid(BlockDirection.north);
                swSolid = chunk.GetBlock(pos.Add(-1, 1, -1)).controller.IsSolid(BlockDirection.north) && chunk.GetBlock(pos.Add(-1, 1, -1)).controller.IsSolid(BlockDirection.east);

                light = chunk.GetBlock(pos.Add(0, 1, 0)).data1 / 255f;

                break;
            case BlockDirection.down:
                nSolid = chunk.GetBlock(pos.Add(0, -1, -1)).controller.IsSolid(BlockDirection.south);
                eSolid = chunk.GetBlock(pos.Add(1, -1, 0)).controller.IsSolid(BlockDirection.west);
                sSolid = chunk.GetBlock(pos.Add(0, -1, 1)).controller.IsSolid(BlockDirection.north);
                wSolid = chunk.GetBlock(pos.Add(-1, -1, 0)).controller.IsSolid(BlockDirection.east);

                wnSolid = chunk.GetBlock(pos.Add(-1, -1, -1)).controller.IsSolid(BlockDirection.east) && chunk.GetBlock(pos.Add(-1, -1, -1)).controller.IsSolid(BlockDirection.south);
                neSolid = chunk.GetBlock(pos.Add(1, -1, -1)).controller.IsSolid(BlockDirection.south) && chunk.GetBlock(pos.Add(1, -1, -1)).controller.IsSolid(BlockDirection.west);
                esSolid = chunk.GetBlock(pos.Add(1, -1, 1)).controller.IsSolid(BlockDirection.west) && chunk.GetBlock(pos.Add(1, -1, 1)).controller.IsSolid(BlockDirection.north);
                swSolid = chunk.GetBlock(pos.Add(-1, -1, 1)).controller.IsSolid(BlockDirection.north) && chunk.GetBlock(pos.Add(-1, -1, 1)).controller.IsSolid(BlockDirection.east);

                light = chunk.GetBlock(pos.Add(0, -1, 0)).data1 / 255f;

                break;
            case BlockDirection.north:
                nSolid = chunk.GetBlock(pos.Add(1, 0, 1)).controller.IsSolid(BlockDirection.west);
                eSolid = chunk.GetBlock(pos.Add(0, 1, 1)).controller.IsSolid(BlockDirection.down);
                sSolid = chunk.GetBlock(pos.Add(-1, 0, 1)).controller.IsSolid(BlockDirection.east);
                wSolid = chunk.GetBlock(pos.Add(0, -1, 1)).controller.IsSolid(BlockDirection.up);

                esSolid = chunk.GetBlock(pos.Add(-1, 1, 1)).controller.IsSolid(BlockDirection.east) && chunk.GetBlock(pos.Add(-1, 1, 1)).controller.IsSolid(BlockDirection.south);
                neSolid = chunk.GetBlock(pos.Add(1, 1, 1)).controller.IsSolid(BlockDirection.south) && chunk.GetBlock(pos.Add(1, 1, 1)).controller.IsSolid(BlockDirection.west);
                wnSolid = chunk.GetBlock(pos.Add(1, -1, 1)).controller.IsSolid(BlockDirection.west) && chunk.GetBlock(pos.Add(1, -1, 1)).controller.IsSolid(BlockDirection.north);
                swSolid = chunk.GetBlock(pos.Add(-1, -1, 1)).controller.IsSolid(BlockDirection.north) && chunk.GetBlock(pos.Add(-1, -1, 1)).controller.IsSolid(BlockDirection.east);

                light = chunk.GetBlock(pos.Add(0, 0, 1)).data1 / 255f;

                break;
            case BlockDirection.east:
                nSolid = chunk.GetBlock(pos.Add(1, 0, -1)).controller.IsSolid(BlockDirection.up);
                eSolid = chunk.GetBlock(pos.Add(1, 1, 0)).controller.IsSolid(BlockDirection.west);
                sSolid = chunk.GetBlock(pos.Add(1, 0, 1)).controller.IsSolid(BlockDirection.down);
                wSolid = chunk.GetBlock(pos.Add(1, -1, 0)).controller.IsSolid(BlockDirection.east);

                esSolid = chunk.GetBlock(pos.Add(1, 1, 1)).controller.IsSolid(BlockDirection.west) && chunk.GetBlock(pos.Add(1, 1, 1)).controller.IsSolid(BlockDirection.north);
                neSolid = chunk.GetBlock(pos.Add(1, 1, -1)).controller.IsSolid(BlockDirection.south) && chunk.GetBlock(pos.Add(1, 1, -1)).controller.IsSolid(BlockDirection.west);
                wnSolid = chunk.GetBlock(pos.Add(1, -1, -1)).controller.IsSolid(BlockDirection.east) && chunk.GetBlock(pos.Add(1, -1, -1)).controller.IsSolid(BlockDirection.north);
                swSolid = chunk.GetBlock(pos.Add(1, -1, 1)).controller.IsSolid(BlockDirection.north) && chunk.GetBlock(pos.Add(1, -1, 1)).controller.IsSolid(BlockDirection.east);

                light = chunk.GetBlock(pos.Add(1, 0, 0)).data1 / 255f;

                break;
            case BlockDirection.south:
                nSolid = chunk.GetBlock(pos.Add(-1, 0, -1)).controller.IsSolid(BlockDirection.down);
                eSolid = chunk.GetBlock(pos.Add(0, 1, -1)).controller.IsSolid(BlockDirection.west);
                sSolid = chunk.GetBlock(pos.Add(1, 0, -1)).controller.IsSolid(BlockDirection.up);
                wSolid = chunk.GetBlock(pos.Add(0, -1, -1)).controller.IsSolid(BlockDirection.south);

                esSolid = chunk.GetBlock(pos.Add(1, 1, -1)).controller.IsSolid(BlockDirection.west) && chunk.GetBlock(pos.Add(1, 1, -1)).controller.IsSolid(BlockDirection.north);
                neSolid = chunk.GetBlock(pos.Add(-1, 1, -1)).controller.IsSolid(BlockDirection.south) && chunk.GetBlock(pos.Add(-1, 1, -1)).controller.IsSolid(BlockDirection.west);
                wnSolid = chunk.GetBlock(pos.Add(-1, -1, -1)).controller.IsSolid(BlockDirection.east) && chunk.GetBlock(pos.Add(-1, -1, -1)).controller.IsSolid(BlockDirection.north);
                swSolid = chunk.GetBlock(pos.Add(1, -1, -1)).controller.IsSolid(BlockDirection.north) && chunk.GetBlock(pos.Add(1, -1, -1)).controller.IsSolid(BlockDirection.east);

                light = chunk.GetBlock(pos.Add(0, 0, -1)).data1 / 255f;

                break;
            case BlockDirection.west:
                nSolid = chunk.GetBlock(pos.Add(-1, 0, 1)).controller.IsSolid(BlockDirection.up);
                eSolid = chunk.GetBlock(pos.Add(-1, 1, 0)).controller.IsSolid(BlockDirection.west);
                sSolid = chunk.GetBlock(pos.Add(-1, 0, -1)).controller.IsSolid(BlockDirection.down);
                wSolid = chunk.GetBlock(pos.Add(-1, -1, 0)).controller.IsSolid(BlockDirection.east);

                esSolid = chunk.GetBlock(pos.Add(-1, 1, -1)).controller.IsSolid(BlockDirection.west) && chunk.GetBlock(pos.Add(-1, 1, -1)).controller.IsSolid(BlockDirection.north);
                neSolid = chunk.GetBlock(pos.Add(-1, 1, 1)).controller.IsSolid(BlockDirection.south) && chunk.GetBlock(pos.Add(-1, 1, 1)).controller.IsSolid(BlockDirection.west);
                wnSolid = chunk.GetBlock(pos.Add(-1, -1, 1)).controller.IsSolid(BlockDirection.east) && chunk.GetBlock(pos.Add(-1, -1, 1)).controller.IsSolid(BlockDirection.north);
                swSolid = chunk.GetBlock(pos.Add(-1, -1, -1)).controller.IsSolid(BlockDirection.north) && chunk.GetBlock(pos.Add(-1, -1, -1)).controller.IsSolid(BlockDirection.east);

                light = chunk.GetBlock(pos.Add(-1, 0, 0)).data1 / 255f;

                break;
            default:
                Debug.LogError("BlockDirection not recognized");
                break;
        }

        AddColors(meshData, wnSolid, nSolid, neSolid, eSolid, esSolid, sSolid, swSolid, wSolid, light);
    }

    public static void BuildTexture(Chunk chunk, BlockPos pos, MeshData meshData, BlockDirection blockDirection, Tile tilePos)
    {
        Vector2[] UVs = new Vector2[4];

        UVs[0] = new Vector2(Config.Env.TileSize * tilePos.x + Config.Env.TileSize, Config.Env.TileSize * tilePos.y);
        UVs[1] = new Vector2(Config.Env.TileSize * tilePos.x + Config.Env.TileSize, Config.Env.TileSize * tilePos.y + Config.Env.TileSize);
        UVs[2] = new Vector2(Config.Env.TileSize * tilePos.x, Config.Env.TileSize * tilePos.y + Config.Env.TileSize);
        UVs[3] = new Vector2(Config.Env.TileSize * tilePos.x, Config.Env.TileSize * tilePos.y);

        meshData.uv.AddRange(UVs);
    }

    public static void BuildTexture(Chunk chunk, BlockPos pos, MeshData meshData, BlockDirection blockDirection, Tile[] tiles)
    {
        Tile tilePos = new Tile();

        switch (blockDirection)
        {
            case BlockDirection.up:
                tilePos = tiles[0];
                break;
            case BlockDirection.down:
                tilePos = tiles[1];
                break;
            case BlockDirection.north:
                tilePos = tiles[2];
                break;
            case BlockDirection.east:
                tilePos = tiles[3];
                break;
            case BlockDirection.south:
                tilePos = tiles[4];
                break;
            case BlockDirection.west:
                tilePos = tiles[5];
                break;
            default:
                break;
        }

        Vector2[] UVs = new Vector2[4];

        UVs[0] = new Vector2(Config.Env.TileSize * tilePos.x + Config.Env.TileSize, Config.Env.TileSize * tilePos.y);
        UVs[1] = new Vector2(Config.Env.TileSize * tilePos.x + Config.Env.TileSize, Config.Env.TileSize * tilePos.y + Config.Env.TileSize);
        UVs[2] = new Vector2(Config.Env.TileSize * tilePos.x, Config.Env.TileSize * tilePos.y + Config.Env.TileSize);
        UVs[3] = new Vector2(Config.Env.TileSize * tilePos.x, Config.Env.TileSize * tilePos.y);

        meshData.uv.AddRange(UVs);
    }

    static void AddQuadToMeshData(Chunk chunk, BlockPos pos, MeshData meshData, BlockDirection blockDirection, bool useCollisionMesh)
    {
        //Adding a tiny overlap between block meshes may solve floating point imprecision
        //errors causing pixel size gaps between blocks when looking closely
        float halfBlock = (Config.Env.BlockSize / 2) + Config.Env.BlockFacePadding;

        //Converting the position to a vector adjusts it based on block size and gives us real world coordinates for x, y and z
        Vector3 vPos = pos;

        switch (blockDirection)
        {
            case BlockDirection.up:
                meshData.AddVertex(new Vector3(vPos.x - halfBlock, vPos.y + halfBlock, vPos.z + halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x + halfBlock, vPos.y + halfBlock, vPos.z + halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x + halfBlock, vPos.y + halfBlock, vPos.z - halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x - halfBlock, vPos.y + halfBlock, vPos.z - halfBlock), useCollisionMesh);
                break;
            case BlockDirection.down:
                meshData.AddVertex(new Vector3(vPos.x - halfBlock, vPos.y - halfBlock, vPos.z - halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x + halfBlock, vPos.y - halfBlock, vPos.z - halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x + halfBlock, vPos.y - halfBlock, vPos.z + halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x - halfBlock, vPos.y - halfBlock, vPos.z + halfBlock), useCollisionMesh);
                break;
            case BlockDirection.north:
                meshData.AddVertex(new Vector3(vPos.x + halfBlock, vPos.y - halfBlock, vPos.z + halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x + halfBlock, vPos.y + halfBlock, vPos.z + halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x - halfBlock, vPos.y + halfBlock, vPos.z + halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x - halfBlock, vPos.y - halfBlock, vPos.z + halfBlock), useCollisionMesh);
                break;
            case BlockDirection.east:
                meshData.AddVertex(new Vector3(vPos.x + halfBlock, vPos.y - halfBlock, vPos.z - halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x + halfBlock, vPos.y + halfBlock, vPos.z - halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x + halfBlock, vPos.y + halfBlock, vPos.z + halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x + halfBlock, vPos.y - halfBlock, vPos.z + halfBlock), useCollisionMesh);
                break;
            case BlockDirection.south:
                meshData.AddVertex(new Vector3(vPos.x - halfBlock, vPos.y - halfBlock, vPos.z - halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x - halfBlock, vPos.y + halfBlock, vPos.z - halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x + halfBlock, vPos.y + halfBlock, vPos.z - halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x + halfBlock, vPos.y - halfBlock, vPos.z - halfBlock), useCollisionMesh);
                break;
            case BlockDirection.west:
                meshData.AddVertex(new Vector3(vPos.x - halfBlock, vPos.y - halfBlock, vPos.z + halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x - halfBlock, vPos.y + halfBlock, vPos.z + halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x - halfBlock, vPos.y + halfBlock, vPos.z - halfBlock), useCollisionMesh);
                meshData.AddVertex(new Vector3(vPos.x - halfBlock, vPos.y - halfBlock, vPos.z - halfBlock), useCollisionMesh);
                break;
            default:
                Debug.LogError("BlockDirection not recognized");
                break;
        }

        meshData.AddQuadTriangles(useCollisionMesh);
    }

    static void AddColors(MeshData meshData, bool wnSolid, bool nSolid, bool neSolid, bool eSolid, bool esSolid, bool sSolid, bool swSolid, bool wSolid, float light)
    {
        float ne = 1;
        float es = 1;
        float sw = 1;
        float wn = 1;

        float aoContrast = 0.2f;

        if (nSolid)
        {
            wn -= aoContrast;
            ne -= aoContrast;
        }

        if (eSolid)
        {
            ne -= aoContrast;
            es -= aoContrast;
        }

        if (sSolid)
        {
            es -= aoContrast;
            sw -= aoContrast;
        }

        if (wSolid)
        {
            sw -= aoContrast;
            wn -= aoContrast;
        }

        if (neSolid)
            ne -= aoContrast;

        if (swSolid)
            sw -= aoContrast;

        if (wnSolid)
            wn -= aoContrast;

        if (esSolid)
            es -= aoContrast;

        meshData.AddColors(ne, es, sw, wn, light);
    }
}
