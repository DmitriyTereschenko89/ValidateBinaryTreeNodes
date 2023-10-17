Solution solution = new();
Console.WriteLine(solution.ValidateBinaryTreeNodes(4, new int[] { 1, -1, 3, -1 }, new int[] { 2, -1, -1, -1 }));
Console.WriteLine(solution.ValidateBinaryTreeNodes(4, new int[] { 1, -1, 3, -1 }, new int[] { 2, 3, -1, -1 }));
Console.WriteLine(solution.ValidateBinaryTreeNodes(2, new int[] { 1, 0 }, new int[] { -1, -1 }));

public class Solution
{
	private class UnionFind
	{
		private int components;
		private readonly int[] parents;
		
		public UnionFind(int n)
		{
			components = n;
			parents = new int[components];
			for (int i = 0; i < n; ++i)
			{
				parents[i] = i;
			}
		}

		public int Find(int node)
		{
			if (parents[node] != node)
			{
				parents[node] = Find(parents[node]);
			}
			return parents[node];
		}

		public bool Union(int parent, int child)
		{
			int parentNode = Find(parent);
			int childParent = Find(child);
			if (childParent != child && parentNode == childParent)
			{
				return false;
			}
			--components;
			parents[childParent] = parentNode;
			return true;
		}

		public int GetComponent() => components;
	}
	public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
	{
		UnionFind uf = new(n);
		for (int node = 0; node < n; ++node)
		{
			int[] childrens = { leftChild[node], rightChild[node] };
			foreach (int child in childrens)
			{
				if (child == -1)
				{
					continue;
				}

				if (!uf.Union(node, child))
				{
					return false;
				}
			}

		}
		return uf.GetComponent() == 1;
	}
}