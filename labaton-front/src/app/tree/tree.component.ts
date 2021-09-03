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
  public flag: boolean = false;
  constructor(private structureService: StructureService) { }

  ngOnInit(): void {
    // if (!this.treeItem) {
    //   this.structureService.getStructure("").subscribe(response => {
    //     this.treeItem = response;
    //   });
    // }

  }

  // public click(path: string): void {
  //   this.structureService.getStructure(path).subscribe(response => {
  //     console.log(response);
  //   });
  // }
}
