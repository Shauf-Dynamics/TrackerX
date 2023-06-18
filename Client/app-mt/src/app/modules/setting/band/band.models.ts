export class Band {
    bandId: number;
    bandName: string;
    songCount: number;

    constructor(bandId: number, bandName: string, songCount: number) {
        this.bandId = bandId;
        this.bandName = bandName;
        this.songCount = songCount;
    }
}