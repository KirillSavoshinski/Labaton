import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TreeItem } from '../models/tree-item';
import { StructureService } from '../services/structure.service';

@Component({
  selector: 'app-tree',
  templateUrl: './tree.component.html',
  styleUrls: ['./tree.component.scss']
})
export class TreeComponent implements OnInit {
  @Input() treeItem: TreeItem;
  @Output() expandedTreeItem = new EventEmitter<TreeItem>();
  
  constructor(private structureService: StructureService) { }

  ngOnInit(): void {
    // if (!this.treeItem) {
    //   this.structureService.getStructure("").subscribe(response => {
    //     this.treeItem = response;
    //   });
    // }
    console.log(this.treeItem);

  }

  public click(path: string): void {
    console.log(path);
    // this.structureService.getStructure(path).subscribe(response => {
    //   console.log(response);
    // });
  }
}
