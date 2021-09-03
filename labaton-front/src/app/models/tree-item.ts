export interface TreeItem {
    path: string,
    children: TreeItem[],
    parent: string;
}