import { Component, OnInit } from '@angular/core';
import { TreeItem } from '../models/tree-item';
import { StructureService } from '../services/structure.service';

@Component({
  selector: 'app-tree',
  templateUrl: './tree.component.html',
  styleUrls: ['./tree.component.scss']
})
export class TreeComponent implements OnInit {
  public treeItems: TreeItem;

  constructor(private structureService: StructureService) { }

  ngOnInit(): void {
    this.structureService.getStructure("").subscribe(response => {
      this.treeItems = response;
    })
  }

}
