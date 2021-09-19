import { Component, Input, OnInit } from '@angular/core';
import { TreeItem } from '../models/tree-item';
import { StructureService } from '../services/structure.service';

@Component({
  selector: 'app-tree',
  templateUrl: './tree.component.html',
  styleUrls: ['./tree.component.scss']
})
export class TreeComponent implements OnInit {
  @Input() treeItem: TreeItem;
  
  constructor(private structureService: StructureService) { }

  ngOnInit(): void {
  }

  public click(path: string): void {
    this.structureService.selectedFolder.next(path.replace('\\','/'));
    this.structureService.getStructure(path).subscribe(response => {
      this.treeItem.children.find(el => el.path === path).children = response.children;
    });
  }
}
